using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HospitalCmsSystem.Application.CQRS.Queries.WorkingHourQueries;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Application.Interfaces.AppointmentInterfaces;
using HospitalCmsSystem.Application.Interfaces.DoctorInterfaces.HospitalCmsSystem.Persistence.Repositories;
using MediatR;

namespace HospitalCmsSystem.Application.CQRS.Handlers.WorkingHourHandlers
{
    public class GetTimeSlotByDoctorIdQueryHandler : IRequestHandler<GetTimeSlotByDoctorIdQuery, List<TimeSlotDto>>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        public GetTimeSlotByDoctorIdQueryHandler(IDoctorRepository doctorRepository, IAppointmentRepository appointmentRepository)
        {
            _doctorRepository = doctorRepository;
            _appointmentRepository = appointmentRepository;
        }

        public async Task<List<TimeSlotDto>> Handle(GetTimeSlotByDoctorIdQuery request, CancellationToken cancellationToken)
        {
            // Retrieve the doctor's working hours
            var doctorWithWorkingHours = await _doctorRepository.GetDoctorWithWorkingHours(request.DoctorId);
            if (doctorWithWorkingHours == null || doctorWithWorkingHours.WorkingHours == null)
            {
                // If there is no doctor or working hours information, return an empty list
                return new List<TimeSlotDto>();
            }

            // Retrieve the working hours for the given date
            var workingHoursOfDay = doctorWithWorkingHours.WorkingHours
                .Where(wh => wh.DayOfWeek == request.Date.DayOfWeek && !wh.IsOffDay)
                .ToList();

            if (!workingHoursOfDay.Any())
            {
                // If there are no working hours for the day, return an empty list
                return new List<TimeSlotDto>();
            }

            // Retrieve existing appointments for the day
            var appointments = await _appointmentRepository.GetAppointmentsByDoctor(request.DoctorId, request.Date);

            // Create a list to store the time slots
            var timeSlots = new List<TimeSlotDto>();

            // Iterate over each working hour range for the day
            foreach (var workingHour in workingHoursOfDay)
            {
                var startTime = workingHour.StartTime;
                while (startTime < workingHour.EndTime)
                {
                    // Create time slots of 30 minutes duration each
                    var endTime = startTime.Add(TimeSpan.FromMinutes(30));

                    // Check if the time slot overlaps with any existing appointment
                    var isTimeSlotTaken = appointments.Any(a =>
                        a.AppointmentDate.TimeOfDay >= startTime && a.AppointmentDate.TimeOfDay < endTime);

                    // Only add time slot if it's not already taken
                    if (!isTimeSlotTaken)
                    {
                        timeSlots.Add(new TimeSlotDto
                        {
                            StartTime = startTime,
                            EndTime = endTime,
                            IsAvailable = true
                        });
                    }

                    // Move to the next time slot
                    startTime = endTime;
                }
            }

            return timeSlots;
        }
    }
}

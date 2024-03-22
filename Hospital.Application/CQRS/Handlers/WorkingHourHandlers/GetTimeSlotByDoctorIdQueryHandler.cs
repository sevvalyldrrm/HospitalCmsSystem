using HospitalCmsSystem.Application.CQRS.Queries.WorkingHourQueries;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Application.Interfaces.AppointmentInterfaces.HospitalCmsSystem.Persistence.Repositories;
using HospitalCmsSystem.Application.Interfaces.DoctorInterfaces.HospitalCmsSystem.Persistence.Repositories;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.WorkingHourHandlers
{
	public class GetTimeSlotByDoctorIdQueryHandler : IRequestHandler<GetTimeSlotByDoctorIdQuery, List<TimeSlotDto>>
	{
		private readonly IDoctorRepository _doctorRepository;
		private readonly IAppointmentRepository _appointmentRepository;

		public async Task<List<TimeSlotDto>> Handle(GetTimeSlotByDoctorIdQuery request, CancellationToken cancellationToken)
		{
			var workingHours = await _doctorRepository
					.GetQueryable(request.DoctorId);

			var workingHour = workingHours
							  .SelectMany(d => d.WorkingHours)
							  .FirstOrDefault(wh => wh.DayOfWeek == request.Date.DayOfWeek && !wh.IsOffDay);

			if (workingHour == null)
			{
				return new List<TimeSlotDto>();
			}

			var appointments = await _appointmentRepository
									.GetAppointmentsByDoctor(request.DoctorId,request.Date);

			var availableTimeSlots = new List<TimeSlotDto>();

			var startTime = workingHour.StartTime;
			while (startTime < workingHour.EndTime)
			{
				var endTime = startTime.Add(TimeSpan.FromMinutes(30));
				var isAvailable = !appointments.Any(a => a.AppointmentDate.Date.TimeOfDay < endTime && a.AppointmentDate.Date.AddMinutes(30).TimeOfDay > startTime);

				availableTimeSlots.Add(new TimeSlotDto
				{
					StartTime = startTime,
					EndTime = endTime,
					IsAvailable = isAvailable
				});

				startTime = endTime; 
			}

			return availableTimeSlots;
		}
	}
}

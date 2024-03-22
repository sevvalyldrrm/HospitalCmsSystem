using HospitalCmsSystem.Application.CQRS.Queries.WorkingHourQueries;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Application.Interfaces.AppointmentInterfaces;
using HospitalCmsSystem.Application.Interfaces.DoctorInterfaces;
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
	public class GetDateByDoctorIdQueryHandler : IRequestHandler<GetDateByDoctorIdQuery, List<AvailableDateDto>>
	{
		private readonly IDoctorRepository _doctorRepository;
		private readonly IAppointmentRepository _appointmentRepository;

		public GetDateByDoctorIdQueryHandler(IDoctorRepository doctorRepository, IAppointmentRepository appointmentRepository)
		{
			_doctorRepository = doctorRepository;
			_appointmentRepository = appointmentRepository;
		}

		public async Task<List<AvailableDateDto>> Handle(GetDateByDoctorIdQuery request, CancellationToken cancellationToken)
		{
			var doctorWithWorkingHours = await _doctorRepository.GetDoctorWithWorkingHours(request.DoctorId);
			var workingHours = doctorWithWorkingHours?.WorkingHours;

			var availableDates = new List<AvailableDateDto>();
			var startDate = DateTime.Now;
			var endDate = DateTime.Now.AddDays(14); // Assuming we are checking for the next two weeks

			for (DateTime date = startDate; date < endDate; date = date.AddDays(1))
			{
				var dayOfWeek = date.DayOfWeek;
				var workingHourForDay = workingHours.FirstOrDefault(wh => wh.DayOfWeek == dayOfWeek && !wh.IsOffDay);

				if (workingHourForDay != null)
				{
					var appointments = await _appointmentRepository.GetAppointmentsByDoctor(request.DoctorId, date);
					bool isAvailable = !appointments.Any(a => a.AppointmentDate.Date == date.Date);
					availableDates.Add(new AvailableDateDto { Date = date, IsAvailable = isAvailable });
				}
			}

			return availableDates;
		}
	}
}

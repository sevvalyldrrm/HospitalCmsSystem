using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Queries.WorkingHourQueries
{
	public class GetTimeSlotByDoctorIdQuery : IRequest<List<TimeSlotDto>>
	{
		public int DoctorId { get; set; }
		public DateTime Date { get; set; }

		public GetTimeSlotByDoctorIdQuery(int doctorId, DateTime date)
		{
			DoctorId = doctorId;
			Date = date;
		}

	}
	public class TimeSlotDto
	{
		public TimeSpan StartTime { get; set; }
		public TimeSpan EndTime { get; set; }
		public bool IsAvailable { get; set; }
	}

}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Queries.WorkingHourQueries
{
	public class GetDateByDoctorIdQuery : IRequest<List<AvailableDateDto>>
	{
		public GetDateByDoctorIdQuery(int doctorId)
		{
			DoctorId = doctorId;
		}

		public int DoctorId { get; set; }
	}
	public class AvailableDateDto
	{
		public DateTime Date { get; set; }
		public bool IsAvailable { get; set; }
	}
}

using HospitalCmsSystem.Application.CQRS.Results.SurgeryDoctorResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Queries.SurgeryDoctorQueries
{
	public class GetSurgeryDoctorByIdQuery : IRequest<GetSurgeryDoctorByIdQueryResult>
	{
		public int Id { get; set; }

        public GetSurgeryDoctorByIdQuery(int id)
        {
            Id = id;
        }
    }
}

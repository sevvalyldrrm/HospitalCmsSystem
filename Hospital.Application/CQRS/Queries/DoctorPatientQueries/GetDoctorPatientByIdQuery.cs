using HospitalCmsSystem.Application.CQRS.Results.DoctorPatientResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Queries.DoctorPatientQueries
{
	public class GetDoctorPatientByIdQuery : IRequest<GetDoctorPatientByIdQueryResult>
	{
		public int Id { get; set; }

        public GetDoctorPatientByIdQuery(int id)
        {
            Id = id;
        }
    }
}

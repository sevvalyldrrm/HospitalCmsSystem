using HospitalCmsSystem.Application.CQRS.Results.PatientResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Queries.PatientQueries
{
	public class GetPatientByIdQuery : IRequest<GetPatientByIdQueryResult>
	{
		public int Id { get; set; }

        public GetPatientByIdQuery(int id)
        {
            Id = id;
        }
    }
}

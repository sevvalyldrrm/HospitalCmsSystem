using HospitalCmsSystem.Application.CQRS.Results.PatientResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Queries.PatientQueries
{
	public class GetPatientQuery : IRequest<List<GetPatientQueryResult>>
	{

	}
}

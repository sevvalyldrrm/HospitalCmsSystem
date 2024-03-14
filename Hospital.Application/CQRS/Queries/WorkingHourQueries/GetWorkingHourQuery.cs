using HospitalCmsSystem.Application.CQRS.Results.WorkingHourResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Queries.WorkingHourQueries
{
	public class GetWorkingHourQuery : IRequest<List<GetWorkingHourQueryResult>>
	{

	}
}

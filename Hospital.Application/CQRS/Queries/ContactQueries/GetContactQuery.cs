using HospitalCmsSystem.Application.CQRS.Results.ContactResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Queries.ContactQueries
{
	public class GetContactQuery : IRequest<List<GetContactQueryResult>>
	{

	}
}

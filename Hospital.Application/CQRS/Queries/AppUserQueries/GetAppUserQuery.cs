using HospitalCmsSystem.Application.CQRS.Results.AppUserResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Queries.AppUserQueries
{
    public class GetAppUserQuery : IRequest<GetAppUserQueryResult>
    {
    }
}

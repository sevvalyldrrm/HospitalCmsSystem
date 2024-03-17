using HospitalCmsSystem.Application.CQRS.Results.BlogResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Queries.BlogQueries
{
    public class GetBlogWithIncludeQuery : IRequest<List<GetBlogWithIncludeQueryResult>>
    {

    }
}

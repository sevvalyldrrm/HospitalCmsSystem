using HospitalCmsSystem.Application.CQRS.Results.BlogImageResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Queries.BlogImageQueries
{
    public class GetBlogImageByIdQuery : IRequest<GetBlogImageByIdQueryResult>
    {
        public int Id { get; set; }

        public GetBlogImageByIdQuery(int id)
        {
            Id = id;
        }
    }
}

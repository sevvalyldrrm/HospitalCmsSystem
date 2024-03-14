using HospitalCmsSystem.Application.CQRS.Results.DepartmentBlogResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Queries.DepartmentBlogQueries
{
	public class GetDepartmentBlogByIdQuery : IRequest<GetDepartmentBlogByIdQueryResult>
	{
		public int Id { get; set; }

        public GetDepartmentBlogByIdQuery(int id)
        {
            Id = id;
        }
    }
}

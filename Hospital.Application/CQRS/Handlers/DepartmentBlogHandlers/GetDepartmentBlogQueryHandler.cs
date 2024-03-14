using HospitalCmsSystem.Application.CQRS.Queries.DepartmentBlogQueries;
using HospitalCmsSystem.Application.CQRS.Results.DepartmentBlogResults;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.DepartmentBlogHandlers
{
	public class GetDepartmentBlogQueryHandler : IRequestHandler<GetDepartmentBlogQuery, List<GetDepartmentBlogQueryResult>>
	{
		private readonly IRepository<DepartmentBlog> _repository;

		public GetDepartmentBlogQueryHandler(IRepository<DepartmentBlog> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetDepartmentBlogQueryResult>> Handle(GetDepartmentBlogQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetDepartmentBlogQueryResult
            {
                BlogId = x.BlogId,
                DepartmentId = x.DepartmentId,
                Id = x.Id
			}).ToList();
		}
	}
}

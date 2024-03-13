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
	public class GetDepartmentBlogByIdQueryHandler : IRequestHandler<GetDepartmentBlogByIdQuery, GetDepartmentBlogByIdQueryResult>
	{
		private readonly IRepository<DepartmentBlog> _repository;

		public GetDepartmentBlogByIdQueryHandler(IRepository<DepartmentBlog> repository)
		{
			_repository = repository;
		}

		public async Task<GetDepartmentBlogByIdQueryResult> Handle(GetDepartmentBlogByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetDepartmentBlogByIdQueryResult
			{
				Id = values.Id,
                BlogId = values.BlogId,
                DepartmentId = values.DepartmentId,
            };

		}
	}
}

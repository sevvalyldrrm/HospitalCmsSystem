using HospitalCmsSystem.Application.CQRS.Queries.BlogImageQueries;
using HospitalCmsSystem.Application.CQRS.Results.BlogImageResults;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.BlogImageHandlers
{
	public class GetBlogImageQueryHandler : IRequestHandler<GetBlogImageQuery, List<GetBlogImageQueryResult>>
	{
		private readonly IRepository<BlogImage> _repository;

		public GetBlogImageQueryHandler(IRepository<BlogImage> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetBlogImageQueryResult>> Handle(GetBlogImageQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetBlogImageQueryResult
            {
                BlogId = x.BlogId,
                ImagePath = x.ImagePath,
                Id = x.Id
			}).ToList();
		}
	}
}

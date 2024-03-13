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
	public class GetBlogImageByIdQueryHandler : IRequestHandler<GetBlogImageByIdQuery, GetBlogImageByIdQueryResult>
	{
		private readonly IRepository<BlogImage> _repository;

		public GetBlogImageByIdQueryHandler(IRepository<BlogImage> repository)
		{
			_repository = repository;
		}

		public async Task<GetBlogImageByIdQueryResult> Handle(GetBlogImageByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetBlogImageByIdQueryResult
			{
				Id = values.Id,
                BlogId = values.BlogId,
                ImagePath = values.ImagePath,
            };

		}
	}
}

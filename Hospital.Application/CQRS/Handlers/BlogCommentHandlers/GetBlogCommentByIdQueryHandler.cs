using HospitalCmsSystem.Application.CQRS.Queries.BlogCommentQueries;
using HospitalCmsSystem.Application.CQRS.Results.BlogCommentResults;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.BlogCommentHandlers
{
	public class GetBlogCommentByIdQueryHandler : IRequestHandler<GetBlogCommentByIdQuery, GetBlogCommentByIdQueryResult>
	{
		private readonly IRepository<BlogComment> _repository;

		public GetBlogCommentByIdQueryHandler(IRepository<BlogComment> repository)
		{
			_repository = repository;
		}

		public async Task<GetBlogCommentByIdQueryResult> Handle(GetBlogCommentByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetBlogCommentByIdQueryResult
			{
				Id = values.Id,
                BlogId = values.BlogId,
                Comment = values.Comment,
                IsActive = values.IsActive,
                AppUserId = values.AppUserId,
            };

		}
	}
}

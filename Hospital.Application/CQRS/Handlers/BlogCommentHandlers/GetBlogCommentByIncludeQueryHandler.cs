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
	public class GetBlogCommentByIncludeQueryHandler : IRequestHandler<GetBlogCommentByIncludeQuery, List<GetBlogCommentByIncludeQueryResult>>
	{
		private readonly IRepository<BlogComment> _repository;

		public GetBlogCommentByIncludeQueryHandler(IRepository<BlogComment> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetBlogCommentByIncludeQueryResult>> Handle(GetBlogCommentByIncludeQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetBlogCommentByIncludeQueryResult
            {
              BlogCommentId=x.Id,
			  Comment=x.Comment,
			  IsActive=x.IsActive,
			
			}).ToList();
		}
	}
}

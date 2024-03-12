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
	public class GetAppointmentManagerQueryHandler : IRequestHandler<GetBlogCommentQuery, List<GetBlogCommentQueryResult>>
	{
		private readonly IRepository<BlogComment> _repository;

		public GetAppointmentManagerQueryHandler(IRepository<BlogComment> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetBlogCommentQueryResult>> Handle(GetBlogCommentQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetBlogCommentQueryResult
			{
                BlogId = x.BlogId,
                Comment = x.Comment,
                IsActive = x.IsActive,
                AppUserId = x.AppUserId,
                Id = x.Id
			}).ToList();
		}
	}
}

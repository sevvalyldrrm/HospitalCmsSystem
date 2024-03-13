using HospitalCmsSystem.Application.CQRS.Queries.BlogQueries;
using HospitalCmsSystem.Application.CQRS.Results.BlogResults;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.BlogHandlers
{
	public class GetAppointmentManagerByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
	{
		private readonly IRepository<Blog> _repository;

		public GetAppointmentManagerByIdQueryHandler(IRepository<Blog> repository)
		{
			_repository = repository;
		}

		public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetBlogByIdQueryResult
			{
				Id = values.Id,
                AppUserId = values.AppUserId,
                Title = values.Title,
                Content = values.Content,
                Tag = values.Tag,
            };

		}
	}
}

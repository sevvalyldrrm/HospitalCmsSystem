﻿using HospitalCmsSystem.Application.CQRS.Queries.BlogQueries;
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
	public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<GetBlogQueryResult>>
	{
		private readonly IRepository<Blog> _repository;

		public GetBlogQueryHandler(IRepository<Blog> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetBlogQueryResult>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetBlogQueryResult
			{
                AppUserId = x.AppUserId,
                Title = x.Title,
                Content = x.Content,
               Tags = x.Tags,
                Id = x.Id,
				Categories = x.Categories,
				CreatedAt = x.CreatedAt,
			}).ToList();
		}
	}
}

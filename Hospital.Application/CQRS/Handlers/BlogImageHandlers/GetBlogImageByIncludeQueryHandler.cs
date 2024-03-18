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
	public class GetBlogImageByIncludeQueryHandler : IRequestHandler<GetBlogImageByIncludeQuery, List<GetBlogImageByIncludeQueryResult>>
	{
		private readonly IRepository<BlogImage> _repository;

		public GetBlogImageByIncludeQueryHandler(IRepository<BlogImage> repository)
		{
			_repository = repository;
		}

        public async Task<List<GetBlogImageByIncludeQueryResult>> Handle(GetBlogImageByIncludeQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetBlogImageByIncludeQueryResult
            {
                
                ImagePath = x.ImagePath,
                BlogImageId=x.Id,
            }).ToList();
        }
    }
}

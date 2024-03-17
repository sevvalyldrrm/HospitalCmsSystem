using HospitalCmsSystem.Application.CQRS.Queries.BlogQueries;
using HospitalCmsSystem.Application.CQRS.Results.BlogCommentResults;
using HospitalCmsSystem.Application.CQRS.Results.BlogImageResults;
using HospitalCmsSystem.Application.CQRS.Results.BlogResults;
using HospitalCmsSystem.Application.Interfaces.BlogInterfaces;
using HospitalCmsSystem.Application.Interfaces.DoctorInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.BlogHandlers
{
    public class GetBlogWithIncludeQueryHandler : IRequestHandler<GetBlogWithIncludeQuery , List<GetBlogWithIncludeQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetBlogWithIncludeQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogWithIncludeQueryResult>> Handle(GetBlogWithIncludeQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetBlogWithInclude();
            var results = values.Select(b => new GetBlogWithIncludeQueryResult
            {
                Id = b.Id,  
                BlogId =  b.Id,
                Title = b.Title,
                Content = b.Content,
                Tag = b.Tag,
                AppUserId = b.AppUserId,
                Categories = b.Categories.ToList(),
                Comment = b.BlogComments.Select(c => new GetBlogCommentQueryResult
                {
                    BlogId=c.Id,
                    Id =c.Id,
                    Comment = c.Comment,
                    AppUserId = c.AppUserId,
                    IsActive = c.IsActive,
                }).ToList(),

                ImagePath = b.BlogImages.Select(c => new GetBlogImageQueryResult{
                    ImagePath = c.ImagePath,
                    BlogId = c.Id,
                    Id =c.Id,   
                }).ToList(),
            }).ToList();
           
            return results;

        }
    }
}

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
                BlogId=b.Id,
                Categories = b.Categories.ToList(),
                Tags = b.Tags.ToList(),
                Title=b.Title,
                Content=b.Content,
                CreatedAt=b.CreatedAt,

                Comment = b.BlogComments.Select(c => new GetBlogCommentByIncludeQueryResult
                {
                   IsActive=c.IsActive,
                   BlogCommentId = c.Id,
                   Comment = c.Comment,
                }).ToList(),

                ImagePath = b.BlogImages.Select(c => new GetBlogImageByIncludeQueryResult
                {
                    BlogImageId = c.Id,
                    ImagePath = c.ImagePath,
                }).ToList(),
            }).ToList();

            return results;
        }
    }

}
    


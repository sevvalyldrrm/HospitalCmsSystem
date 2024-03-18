using HospitalCmsSystem.Application.CQRS.Commands.BlogCommentCommands;
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
	public class CreateBlogCommentCommandHandler : IRequestHandler<CreateBlogCommentCommand>
	{
		private readonly IRepository<BlogComment> _repository;

		public CreateBlogCommentCommandHandler(IRepository<BlogComment> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateBlogCommentCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync( new BlogComment()
			{
                BlogId = request.BlogId,
                Comment = request.Comment,
                IsActive = request.IsActive,
                AppUserId = request.AppUserId,
            });
		}
	}
}

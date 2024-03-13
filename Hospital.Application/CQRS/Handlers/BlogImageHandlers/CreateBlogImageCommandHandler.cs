using HospitalCmsSystem.Application.CQRS.Commands.BlogImageCommands;
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
	public class CreateBlogImageCommandHandler : IRequestHandler<CreateBlogImageCommand>
	{
		private readonly IRepository<BlogImage> _repository;

		public CreateBlogImageCommandHandler(IRepository<BlogImage> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateBlogImageCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync( new BlogImage()
			{
			 BlogId= request.BlogId,
			 ImagePath= request.ImagePath,
				
			});
		}
	}
}

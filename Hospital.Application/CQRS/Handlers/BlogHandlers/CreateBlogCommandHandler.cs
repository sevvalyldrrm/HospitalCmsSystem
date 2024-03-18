using HospitalCmsSystem.Application.CQRS.Commands.BlogCommands;
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
	public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand>
	{
		private readonly IRepository<Blog> _repository;

		public CreateBlogCommandHandler(IRepository<Blog> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync( new Blog()
			{
				AppUserId= request.AppUserId,
				Title= request.Title,
				Content= request.Content,
				Tags= request.Tags,
				Categories= request.Categories,
				CreatedAt= DateTime.Now,

			});
		}
	}
}

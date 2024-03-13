using HospitalCmsSystem.Application.CQRS.Commands.DepartmentBlogCommands;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.DepartmentBlogHandlers
{
	public class CreateDepartmentBlogCommandHandler : IRequestHandler<CreateDepartmentBlogCommand>
	{
		private readonly IRepository<DepartmentBlog> _repository;

		public CreateDepartmentBlogCommandHandler(IRepository<DepartmentBlog> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateDepartmentBlogCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync( new DepartmentBlog()
			{
			 BlogId= request.BlogId,
			 DepartmentId= request.DepartmentId,
				
			});
		}
	}
}

using HospitalCmsSystem.Application.CQRS.Commands.DepartmentBlogCommands;
using HospitalCmsSystem.Application.CQRS.Results.DepartmentBlogResults;
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
	public class RemoveDepartmentBlogCommandHandler : IRequestHandler<RemoveDepartmentBlogCommand>
	{
		private readonly IRepository<DepartmentBlog> _repository;

		public RemoveDepartmentBlogCommandHandler(IRepository<DepartmentBlog> repository)
		{
			_repository = repository;
		}
		public async Task Handle(RemoveDepartmentBlogCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(value);
		}
	}
}

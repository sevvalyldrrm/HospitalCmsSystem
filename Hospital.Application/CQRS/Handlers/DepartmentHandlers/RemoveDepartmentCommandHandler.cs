using HospitalCmsSystem.Application.CQRS.Commands.DepartmentCommands;
using HospitalCmsSystem.Application.CQRS.Results.DepartmentResults;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.DepartmentHandlers
{
	public class RemoveDepartmentCommandHandler : IRequestHandler<RemoveDepartmentCommand>
	{
		private readonly IRepository<Department> _repository;

		public RemoveDepartmentCommandHandler(IRepository<Department> repository)
		{
			_repository = repository;
		}
		public async Task Handle(RemoveDepartmentCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(value);
		}
	}
}

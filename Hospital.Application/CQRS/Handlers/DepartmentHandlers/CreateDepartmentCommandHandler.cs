using HospitalCmsSystem.Application.CQRS.Commands.DepartmentCommands;
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
	public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand>
	{
		private readonly IRepository<Department> _repository;

		public CreateDepartmentCommandHandler(IRepository<Department> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync( new Department()
			{
			 Name=request.Name,
			 Description=request.Description,
			 DepartmentDetailsId=request.DepartmentDetailsId,
			 ImagePath=request.ImagePath,
				
			});
		}
	}
}

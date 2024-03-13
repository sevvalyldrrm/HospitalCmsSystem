using HospitalCmsSystem.Application.CQRS.Commands.DepartmentDetailCommands;
using HospitalCmsSystem.Application.CQRS.Results.DepartmentDetailResults;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.DepartmentDetailHandlers
{
	public class RemoveDepartmentDetailCommandHandler : IRequestHandler<RemoveDepartmentDetailCommand>
	{
		private readonly IRepository<DepartmentDetail> _repository;

		public RemoveDepartmentDetailCommandHandler(IRepository<DepartmentDetail> repository)
		{
			_repository = repository;
		}
		public async Task Handle(RemoveDepartmentDetailCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(value);
		}
	}
}

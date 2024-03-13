using HospitalCmsSystem.Application.CQRS.Commands.AdminCommands;
using HospitalCmsSystem.Application.CQRS.Results.AdminResults;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.AdminHandlers
{
	public class RemoveAdminCommandHandler : IRequestHandler<RemoveAdminCommand>
	{
		private readonly IRepository<Admin> _repository;

		public RemoveAdminCommandHandler(IRepository<Admin> repository)
		{
			_repository = repository;
		}
		public async Task Handle(RemoveAdminCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(value);
		}
	}
}

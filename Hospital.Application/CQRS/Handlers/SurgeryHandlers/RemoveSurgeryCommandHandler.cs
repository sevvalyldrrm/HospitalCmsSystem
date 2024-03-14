using HospitalCmsSystem.Application.CQRS.Commands.SurgeryCommands;
using HospitalCmsSystem.Application.CQRS.Results.SurgeryResults;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.SurgeryHandlers
{
	public class RemoveSurgeryCommandHandler : IRequestHandler<RemoveSurgeryCommand>
	{
		private readonly IRepository<Surgery> _repository;

		public RemoveSurgeryCommandHandler(IRepository<Surgery> repository)
		{
			_repository = repository;
		}
		public async Task Handle(RemoveSurgeryCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(value);
		}
	}
}

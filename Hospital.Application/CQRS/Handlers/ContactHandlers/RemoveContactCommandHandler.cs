using HospitalCmsSystem.Application.CQRS.Commands.ContactCommands;
using HospitalCmsSystem.Application.CQRS.Results.ContactResults;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.ContactHandlers
{
	public class RemoveContactCommandHandler : IRequestHandler<RemoveContactCommand>
	{
		private readonly IRepository<Contact> _repository;

		public RemoveContactCommandHandler(IRepository<Contact> repository)
		{
			_repository = repository;
		}
		public async Task Handle(RemoveContactCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(value);
		}
	}
}

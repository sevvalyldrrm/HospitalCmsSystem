using HospitalCmsSystem.Application.CQRS.Commands.ContactCommands;
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
	public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand>
	{
		private readonly IRepository<Contact> _repository;

		public CreateContactCommandHandler(IRepository<Contact> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateContactCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync( new Contact()
			{
			 FullName=request.FullName,
			 Email=request.Email,
			 Phone=request.Phone,
			 Title=request.Title,
			 Message=request.Message,
				
			});
		}
	}
}

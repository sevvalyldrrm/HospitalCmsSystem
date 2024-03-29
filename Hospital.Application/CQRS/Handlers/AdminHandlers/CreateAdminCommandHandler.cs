﻿using HospitalCmsSystem.Application.CQRS.Commands.AdminCommands;
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
	public class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand>
	{
		private readonly IRepository<Admin> _repository;

		public CreateAdminCommandHandler(IRepository<Admin> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateAdminCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync( new Admin()
			{
			 GitHubAcc=request.GitHubAcc,
			 Name=request.Name,
				
			});
		}
	}
}

using HospitalCmsSystem.Application.CQRS.Commands.EducationCommands;
using HospitalCmsSystem.Application.CQRS.Results.EducationResults;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.EducationHandlers
{
	public class RemoveEducationCommandHandler : IRequestHandler<RemoveEducationCommand>
	{
		private readonly IRepository<Education> _repository;

		public RemoveEducationCommandHandler(IRepository<Education> repository)
		{
			_repository = repository;
		}
		public async Task Handle(RemoveEducationCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(value);
		}
	}
}

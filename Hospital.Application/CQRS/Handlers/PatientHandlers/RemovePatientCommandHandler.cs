using HospitalCmsSystem.Application.CQRS.Commands.PatientCommands;
using HospitalCmsSystem.Application.CQRS.Results.PatientResults;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.PatientHandlers
{
	public class RemovePatientCommandHandler : IRequestHandler<RemovePatientCommand>
	{
		private readonly IRepository<Patient> _repository;

		public RemovePatientCommandHandler(IRepository<Patient> repository)
		{
			_repository = repository;
		}
		public async Task Handle(RemovePatientCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(value);
		}
	}
}

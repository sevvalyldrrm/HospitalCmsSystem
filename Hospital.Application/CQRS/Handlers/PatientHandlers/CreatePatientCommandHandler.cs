using HospitalCmsSystem.Application.CQRS.Commands.PatientCommands;
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
	public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand>
	{
		private readonly IRepository<Patient> _repository;

		public CreatePatientCommandHandler(IRepository<Patient> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreatePatientCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync( new Patient()
			{
			Diagnosis=request.Diagnosis,
			IsDischarged	= request.IsDischarged,
			RoleId=request.RoleId,
			});
		}
	}
}

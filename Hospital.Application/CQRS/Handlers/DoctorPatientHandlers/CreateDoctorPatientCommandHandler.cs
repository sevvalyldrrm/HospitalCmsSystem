using HospitalCmsSystem.Application.CQRS.Commands.DoctorPatientCommands;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.DoctorPatientHandlers
{
	public class CreateDoctorPatientCommandHandler : IRequestHandler<CreateDoctorPatientCommand>
	{
		private readonly IRepository<DoctorPatient> _repository;

		public CreateDoctorPatientCommandHandler(IRepository<DoctorPatient> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateDoctorPatientCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync( new DoctorPatient()
			{
			DoctorId= request.DoctorId,
			PatientId= request.PatientId,
			});
		}
	}
}

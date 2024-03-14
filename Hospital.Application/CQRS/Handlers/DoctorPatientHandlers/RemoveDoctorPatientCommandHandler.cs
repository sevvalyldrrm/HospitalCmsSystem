using HospitalCmsSystem.Application.CQRS.Commands.DoctorPatientCommands;
using HospitalCmsSystem.Application.CQRS.Results.DoctorPatientResults;
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
	public class RemoveDoctorPatientCommandHandler : IRequestHandler<RemoveDoctorPatientCommand>
	{
		private readonly IRepository<DoctorPatient> _repository;

		public RemoveDoctorPatientCommandHandler(IRepository<DoctorPatient> repository)
		{
			_repository = repository;
		}
		public async Task Handle(RemoveDoctorPatientCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(value);
		}
	}
}

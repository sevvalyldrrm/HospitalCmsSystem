using HospitalCmsSystem.Application.CQRS.Commands.SurgeryDoctorCommands;
using HospitalCmsSystem.Application.CQRS.Results.SurgeryDoctorResults;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.SurgeryDoctorHandlers
{
	public class RemoveSurgeryDoctorCommandHandler : IRequestHandler<RemoveSurgeryDoctorCommand>
	{
		private readonly IRepository<SurgeryDoctor> _repository;

		public RemoveSurgeryDoctorCommandHandler(IRepository<SurgeryDoctor> repository)
		{
			_repository = repository;
		}
		public async Task Handle(RemoveSurgeryDoctorCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(value);
		}
	}
}

using HospitalCmsSystem.Application.CQRS.Commands.SurgeryDoctorCommands;
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
	public class CreateSurgeryDoctorCommandHandler : IRequestHandler<CreateSurgeryDoctorCommand>
	{
		private readonly IRepository<SurgeryDoctor> _repository;

		public CreateSurgeryDoctorCommandHandler(IRepository<SurgeryDoctor> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateSurgeryDoctorCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync( new SurgeryDoctor()
			{
			 DoctorId = request.DoctorId,
			SurgeryId= request.SurgeryId,
			});
		}
	}
}

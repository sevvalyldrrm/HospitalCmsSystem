using HospitalCmsSystem.Application.CQRS.Commands.SurgeryCommands;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.SurgeryHandlers
{
	public class CreateSurgeryCommandHandler : IRequestHandler<CreateSurgeryCommand>
	{
		private readonly IRepository<Surgery> _repository;

		public CreateSurgeryCommandHandler(IRepository<Surgery> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateSurgeryCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync( new Surgery()
			{
			 PatientId = request.PatientId,
			 DepartmentId = request.DepartmentId,
			 SurgeryDate = request.SurgeryDate,
				
			});
		}
	}
}

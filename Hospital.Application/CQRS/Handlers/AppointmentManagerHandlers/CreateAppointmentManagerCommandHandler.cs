using HospitalCmsSystem.Application.CQRS.Commands.AppointmentManagerCommands;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.AppointmentManagerHandlers
{
	public class CreateAppointmentManagerCommandHandler : IRequestHandler<CreateAppointmentManagerCommand>
	{
		private readonly IRepository<AppointmentManager> _repository;

		public CreateAppointmentManagerCommandHandler(IRepository<AppointmentManager> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateAppointmentManagerCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync( new AppointmentManager()
			{
				DoctorId= request.DoctorId,
				PatientId= request.PatientId,
				StartingTime= request.StartingTime,
				EndingTime= request.EndingTime,
				Status= request.Status,
			});
		}
	}
}

using HospitalCmsSystem.Application.CQRS.Commands.AppointmentManagerCommands;
using HospitalCmsSystem.Application.CQRS.Results.AppointmentManagerResults;
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
	public class RemoveAppointmentManagerCommandHandler : IRequestHandler<RemoveAppointmentManagerCommand>
	{
		private readonly IRepository<AppointmentManager> _repository;

		public RemoveAppointmentManagerCommandHandler(IRepository<AppointmentManager> repository)
		{
			_repository = repository;
		}
		public async Task Handle(RemoveAppointmentManagerCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(value);
		}
	}
}

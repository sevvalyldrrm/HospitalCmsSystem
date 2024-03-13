using HospitalCmsSystem.Application.CQRS.Commands.AppointmentCommands;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.AppointmentHandlers
{

    public class RemoveAppointmentCommandHandler : IRequestHandler<RemoveAppointmentCommand>
    {
        private readonly IRepository<Appointment> _repository;

        public RemoveAppointmentCommandHandler(IRepository<Appointment> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveAppointmentCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}

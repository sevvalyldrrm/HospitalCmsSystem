using HospitalCmsSystem.Application.CQRS.Commands.AppointmentManagerCommands;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.AppointmentManagerHandlers
{
    public class UpdateAppointmentManagerCommandHandler : IRequestHandler<UpdateAppointmentManagerCommand>
    {
        private readonly IRepository<AppointmentManager> _repository;

        public UpdateAppointmentManagerCommandHandler(IRepository<AppointmentManager> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAppointmentManagerCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);

            values.DoctorId = request.DoctorId;
            values.PatientId = request.PatientId;
            values.StartingTime = request.StartingTime;
            values.EndingTime = request.EndingTime;
            values.Status = request.Status;
            await _repository.UpdateAsync(values);
        }
    }
    
    
}

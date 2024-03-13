using HospitalCmsSystem.Application.CQRS.Commands.AppointmentCommands;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.AppointmentHandlers
{
    public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand>
    {
        private readonly IRepository<Appointment> _repository;

        public UpdateAppointmentCommandHandler(IRepository<Appointment> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.DepartmentId = request.DepartmentId;
            values.DoctorId = request.DoctorId;
            values.PatientId = request.PatientId;
            values.Email = request.Email;
            values.FullName = request.FullName;
            values.Phone = request.Phone;
            values.Message = request.Message;
            values.AppointmentDate = request.AppointmentDate;
            values.AppointmentManagerId = request.AppointmentManagerId;

            await _repository.UpdateAsync(values);
        }
    }
}
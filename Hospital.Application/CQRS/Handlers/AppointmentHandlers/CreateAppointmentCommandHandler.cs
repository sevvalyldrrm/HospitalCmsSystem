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
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand>
    {
        private readonly IRepository<Appointment> _repository;

        public CreateAppointmentCommandHandler(IRepository<Appointment> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Appointment()
            {
                DepartmentId=request.DepartmentId,
                DoctorId = request.DoctorId,
                PatientId=request.PatientId,
                Email=request.Email,
                FullName=request.FullName,
                Phone=request.Phone,
                Message=request.Message,
                AppointmentDate = request.AppointmentDate,
                AppointmentManagerId=request.AppointmentManagerId,
            });
        }
    }
}

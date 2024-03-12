using HospitalCmsSystem.Application.CQRS.Queries.AppointmentQueries;
using HospitalCmsSystem.Application.CQRS.Results.AppointmentResults;
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
    public class GetAppointmentByIdQueryHandler : IRequestHandler<GetAppointmentByIdQuery, GetAppointmentByIdQueryResult>
    {
        private readonly IRepository<Appointment> _repository;

        public GetAppointmentByIdQueryHandler(IRepository<Appointment> repository)
        {
            _repository = repository;
        }

        public async Task<GetAppointmentByIdQueryResult> Handle(GetAppointmentByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetAppointmentByIdQueryResult
            {
                Id = values.Id,
                DepartmentId = values.DepartmentId,
                DoctorId = values.DoctorId,
                PatientId = values.PatientId,
                Email = values.Email,
                FullName = values.FullName,
                Phone = values.Phone,
                Message = values.Message,
                AppointmentDate = values.AppointmentDate,
                AppointmentManagerId = values.AppointmentManagerId,
            };

        }
    }
}

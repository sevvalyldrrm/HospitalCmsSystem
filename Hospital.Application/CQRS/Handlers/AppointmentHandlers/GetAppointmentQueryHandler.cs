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
    public class GetAppointmentQueryHandler : IRequestHandler<GetAppointmentQuery, List<GetAppointmentQueryResult>>
    {
        private readonly IRepository<Appointment> _repository;

        public GetAppointmentQueryHandler(IRepository<Appointment> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAppointmentQueryResult>> Handle(GetAppointmentQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAppointmentQueryResult
            {
                Id = x.Id,
                DepartmentId = x.DepartmentId,
                DoctorId = x.DoctorId,
                PatientId = x.PatientId,
                Email = x.Email,
                FullName = x.FullName,
                Phone = x.Phone,
                Message = x.Message,
                AppointmentDate = x.AppointmentDate,
                AppointmentManagerId = x.AppointmentManagerId,
            }).ToList();
        }
    }
}

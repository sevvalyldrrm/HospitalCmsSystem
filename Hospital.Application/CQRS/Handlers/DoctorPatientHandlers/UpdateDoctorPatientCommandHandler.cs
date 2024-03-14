using HospitalCmsSystem.Application.CQRS.Commands.DoctorPatientCommands;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HospitalCmsSystem.Application.CQRS.Handlers.DoctorPatientHandlers
{
    public class UpdateDoctorPatientCommandHandler : IRequestHandler<UpdateDoctorPatientCommand>
    {
        private readonly IRepository<DoctorPatient> _repository;

        public UpdateDoctorPatientCommandHandler(IRepository<DoctorPatient> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateDoctorPatientCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.DoctorId = request.DoctorId;
			values.PatientId = request.PatientId;
            await _repository.UpdateAsync(values);
        }
    }
    
    
}

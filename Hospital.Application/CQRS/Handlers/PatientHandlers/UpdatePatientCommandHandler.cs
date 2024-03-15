using HospitalCmsSystem.Application.CQRS.Commands.PatientCommands;
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

namespace HospitalCmsSystem.Application.CQRS.Handlers.PatientHandlers
{
    public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand>
    {
        private readonly IRepository<Patient> _repository;

        public UpdatePatientCommandHandler(IRepository<Patient> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.Diagnosis = request.Diagnosis;
            values.IsDischarged = request.IsDischarged;
            values.RoleId = request.RoleId;
            values.Name = request.Name;
            await _repository.UpdateAsync(values);
        }
    }
    
    
}

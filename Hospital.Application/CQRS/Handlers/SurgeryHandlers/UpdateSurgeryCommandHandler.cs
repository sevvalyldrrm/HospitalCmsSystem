using HospitalCmsSystem.Application.CQRS.Commands.SurgeryCommands;
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

namespace HospitalCmsSystem.Application.CQRS.Handlers.SurgeryHandlers
{
    public class UpdateSurgeryCommandHandler : IRequestHandler<UpdateSurgeryCommand>
    {
        private readonly IRepository<Surgery> _repository;

        public UpdateSurgeryCommandHandler(IRepository<Surgery> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateSurgeryCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.PatientId = request.PatientId;
            values.DepartmentId = request.DepartmentId;
            values.SurgeryDate = request.SurgeryDate;
            await _repository.UpdateAsync(values);
        }
    }
    
    
}

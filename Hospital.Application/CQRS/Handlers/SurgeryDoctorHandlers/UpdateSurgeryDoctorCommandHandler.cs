using HospitalCmsSystem.Application.CQRS.Commands.SurgeryDoctorCommands;
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

namespace HospitalCmsSystem.Application.CQRS.Handlers.SurgeryDoctorHandlers
{
    public class UpdateSurgeryDoctorCommandHandler : IRequestHandler<UpdateSurgeryDoctorCommand>
    {
        private readonly IRepository<SurgeryDoctor> _repository;

        public UpdateSurgeryDoctorCommandHandler(IRepository<SurgeryDoctor> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateSurgeryDoctorCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.DoctorId = request.DoctorId;
			values.SurgeryId = request.SurgeryId;
            await _repository.UpdateAsync(values);
        }
    }
    
    
}

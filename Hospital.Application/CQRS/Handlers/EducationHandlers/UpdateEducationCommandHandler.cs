using HospitalCmsSystem.Application.CQRS.Commands.EducationCommands;
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

namespace HospitalCmsSystem.Application.CQRS.Handlers.EducationHandlers
{
    public class UpdateEducationCommandHandler : IRequestHandler<UpdateEducationCommand>
    {
        private readonly IRepository<Education> _repository;

        public UpdateEducationCommandHandler(IRepository<Education> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateEducationCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.Year = request.Year;
			values.University = request.University;
			values.Explanation = request.Explanation;
			values.DoctorId = request.DoctorId;
            await _repository.UpdateAsync(values);
        }
    }
    
    
}

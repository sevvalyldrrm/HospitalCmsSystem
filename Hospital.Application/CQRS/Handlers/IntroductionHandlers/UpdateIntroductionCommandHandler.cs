using HospitalCmsSystem.Application.CQRS.Commands.IntroductionCommands;
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

namespace HospitalCmsSystem.Application.CQRS.Handlers.IntroductionHandlers
{
    public class UpdateIntroductionCommandHandler : IRequestHandler<UpdateIntroductionCommand>
    {
        private readonly IRepository<Introduction> _repository;

        public UpdateIntroductionCommandHandler(IRepository<Introduction> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateIntroductionCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.MySkills = request.MySkills;
            values.Description = request.Description;
		    values.DoctorId = request.DoctorId;
			values.WorkingHour = request.WorkingHour;
            await _repository.UpdateAsync(values);
        }
    }
    
    
}

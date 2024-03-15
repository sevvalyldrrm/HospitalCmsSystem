using HospitalCmsSystem.Application.CQRS.Commands.DoctorCommands;
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

namespace HospitalCmsSystem.Application.CQRS.Handlers.DoctorHandlers
{
    public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand>
    {
        private readonly IRepository<Doctor> _repository;

        public UpdateDoctorCommandHandler(IRepository<Doctor> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.Speacialty = request.Speacialty;
            values.DepartmentId = request.DepartmentId;
            values.RoleId = request.RoleId;
            values.IntroductionId = request.IntroductionId;
            values.DocFacebook = request.DocFacebook;
            values.DocX = request.DocX;
            values.DocPinterest = request.DocPinterest;
            values.DocSkype = request.DocSkype;
            values.DocLinkedIn = request.DocLinkedIn;
            values.DocTitle = request.DocTitle;
            values.Name  = request.Name;
            await _repository.UpdateAsync(values);
        }
    }
    
    
}

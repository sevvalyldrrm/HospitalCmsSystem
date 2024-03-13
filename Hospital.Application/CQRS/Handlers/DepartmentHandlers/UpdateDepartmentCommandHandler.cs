using HospitalCmsSystem.Application.CQRS.Commands.DepartmentCommands;
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

namespace HospitalCmsSystem.Application.CQRS.Handlers.DepartmentHandlers
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand>
    {
        private readonly IRepository<Department> _repository;

        public UpdateDepartmentCommandHandler(IRepository<Department> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);

            values.Name = request.Name;
            values.Description = request.Description;
            values.DepartmentDetailsId = request.DepartmentDetailsId;
            values.ImagePath = request.ImagePath;
            await _repository.UpdateAsync(values);
        }
    }
    
    
}

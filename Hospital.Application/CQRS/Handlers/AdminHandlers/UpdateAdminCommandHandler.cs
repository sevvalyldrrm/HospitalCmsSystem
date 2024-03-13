using HospitalCmsSystem.Application.CQRS.Commands.AdminCommands;
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

namespace HospitalCmsSystem.Application.CQRS.Handlers.AdminHandlers
{
    public class UpdateAdminCommandHandler : IRequestHandler<UpdateAdminCommand>
    {
        private readonly IRepository<Admin> _repository;

        public UpdateAdminCommandHandler(IRepository<Admin> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.GitHubAcc = request.GitHubAcc;
            await _repository.UpdateAsync(values);
        }
    }
    
    
}

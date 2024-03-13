using HospitalCmsSystem.Application.CQRS.Commands.ContactCommands;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HospitalCmsSystem.Application.CQRS.Handlers.ContactHandlers
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand>
    {
        private readonly IRepository<Contact> _repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.FullName = request.FullName;
            values.Email = request.Email;
            values.Phone = request.Phone;
            values.Title = request.Title;
            values.Message = request.Message;
            await _repository.UpdateAsync(values);
        }
    }
    
    
}

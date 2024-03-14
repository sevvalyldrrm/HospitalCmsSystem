using HospitalCmsSystem.Application.CQRS.Commands.DepartmentBlogCommands;
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

namespace HospitalCmsSystem.Application.CQRS.Handlers.DepartmentBlogHandlers
{
    public class UpdateDepartmentBlogCommandHandler : IRequestHandler<UpdateDepartmentBlogCommand>
    {
        private readonly IRepository<DepartmentBlog> _repository;

        public UpdateDepartmentBlogCommandHandler(IRepository<DepartmentBlog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateDepartmentBlogCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.BlogId = request.BlogId;
            values.DepartmentId = request.DepartmentId;
            await _repository.UpdateAsync(values);
        }
    }
    
    
}

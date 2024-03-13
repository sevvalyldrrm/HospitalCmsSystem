using HospitalCmsSystem.Application.CQRS.Commands.BlogImageCommands;
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

namespace HospitalCmsSystem.Application.CQRS.Handlers.BlogImageHandlers
{
    public class UpdateBlogImageCommandHandler : IRequestHandler<UpdateBlogImageCommand>
    {
        private readonly IRepository<BlogImage> _repository;

        public UpdateBlogImageCommandHandler(IRepository<BlogImage> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBlogImageCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.BlogId = request.BlogId;
            values.ImagePath = request.ImagePath;
            await _repository.UpdateAsync(values);
        }
    }
    
    
}

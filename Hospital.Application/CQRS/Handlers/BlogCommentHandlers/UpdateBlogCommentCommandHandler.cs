using HospitalCmsSystem.Application.CQRS.Commands.BlogCommentCommands;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.BlogCommentHandlers
{
    public class UpdateAppointmentManagerCommandHandler : IRequestHandler<UpdateBlogCommentCommand>
    {
        private readonly IRepository<BlogComment> _repository;

        public UpdateAppointmentManagerCommandHandler(IRepository<BlogComment> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBlogCommentCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.BlogId = request.BlogId;
            values.Comment = request.Comment;
            values.IsActive = request.IsActive;
            values.AppUserId = request.AppUserId;
            await _repository.UpdateAsync(values);
        }
    }
    
    
}

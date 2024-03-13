using HospitalCmsSystem.Application.CQRS.Commands.BlogCommentCommands;
using HospitalCmsSystem.Application.CQRS.Results.BlogCommentResults;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.BlogCommentHandlers
{
	public class RemoveAppointmentManagerCommandHandler : IRequestHandler<RemoveBlogCommentCommand>
	{
		private readonly IRepository<BlogComment> _repository;

		public RemoveAppointmentManagerCommandHandler(IRepository<BlogComment> repository)
		{
			_repository = repository;
		}
		public async Task Handle(RemoveBlogCommentCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(value);
		}
	}
}

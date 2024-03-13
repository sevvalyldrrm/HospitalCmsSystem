using HospitalCmsSystem.Application.CQRS.Commands.BlogImageCommands;
using HospitalCmsSystem.Application.CQRS.Results.BlogImageResults;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.BlogImageHandlers
{
	public class RemoveBlogImageCommandHandler : IRequestHandler<RemoveBlogImageCommand>
	{
		private readonly IRepository<BlogImage> _repository;

		public RemoveBlogImageCommandHandler(IRepository<BlogImage> repository)
		{
			_repository = repository;
		}
		public async Task Handle(RemoveBlogImageCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(value);
		}
	}
}

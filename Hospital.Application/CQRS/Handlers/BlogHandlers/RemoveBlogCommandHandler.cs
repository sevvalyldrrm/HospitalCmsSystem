using HospitalCmsSystem.Application.CQRS.Commands.BlogCommands;
using HospitalCmsSystem.Application.CQRS.Results.BlogResults;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.BlogHandlers
{
	public class RemoveBlogCommandHandler : IRequestHandler<RemoveBlogCommand>
	{
		private readonly IRepository<Blog> _repository;

		public RemoveBlogCommandHandler(IRepository<Blog> repository)
		{
			_repository = repository;
		}
		public async Task Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(value);
		}
	}
}

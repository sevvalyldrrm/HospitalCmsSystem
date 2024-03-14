using HospitalCmsSystem.Application.CQRS.Commands.IntroductionCommands;
using HospitalCmsSystem.Application.CQRS.Results.IntroductionResults;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.IntroductionHandlers
{
	public class RemoveIntroductionCommandHandler : IRequestHandler<RemoveIntroductionCommand>
	{
		private readonly IRepository<Introduction> _repository;

		public RemoveIntroductionCommandHandler(IRepository<Introduction> repository)
		{
			_repository = repository;
		}
		public async Task Handle(RemoveIntroductionCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(value);
		}
	}
}

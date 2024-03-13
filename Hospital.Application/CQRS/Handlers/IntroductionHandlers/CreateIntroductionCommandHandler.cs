using HospitalCmsSystem.Application.CQRS.Commands.IntroductionCommands;
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
	public class CreateIntroductionCommandHandler : IRequestHandler<CreateIntroductionCommand>
	{
		private readonly IRepository<Introduction> _repository;

		public CreateIntroductionCommandHandler(IRepository<Introduction> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateIntroductionCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync( new Introduction()
			{
			 MySkills = request.MySkills,
			 Description = request.Description,
			 DoctorId = request.DoctorId,
			 WorkingHour = request.WorkingHour,
			

			});
		}
	}
}

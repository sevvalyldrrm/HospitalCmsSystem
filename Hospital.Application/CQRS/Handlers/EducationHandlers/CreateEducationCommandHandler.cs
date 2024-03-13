using HospitalCmsSystem.Application.CQRS.Commands.EducationCommands;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.EducationHandlers
{
	public class CreateEducationCommandHandler : IRequestHandler<CreateEducationCommand>
	{
		private readonly IRepository<Education> _repository;

		public CreateEducationCommandHandler(IRepository<Education> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateEducationCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync( new Education()
			{
			Year = request.Year,
			University = request.University,
			Explanation = request.Explanation,
			DoctorId = request.DoctorId,
				
			});
		}
	}
}

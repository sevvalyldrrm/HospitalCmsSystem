using HospitalCmsSystem.Application.CQRS.Commands.WorkingHourCommands;
using HospitalCmsSystem.Application.CQRS.Results.WorkingHourResults;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.WorkingHourHandlers
{
	public class RemoveWorkingHourCommandHandler : IRequestHandler<RemoveWorkingHourCommand>
	{
		private readonly IRepository<WorkingHour> _repository;

		public RemoveWorkingHourCommandHandler(IRepository<WorkingHour> repository)
		{
			_repository = repository;
		}
		public async Task Handle(RemoveWorkingHourCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(value);
		}
	}
}

using HospitalCmsSystem.Application.CQRS.Commands.WorkingHourCommands;
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
	public class CreateWorkingHourCommandHandler : IRequestHandler<CreateWorkingHourCommand>
	{
		private readonly IRepository<WorkingHour> _repository;

		public CreateWorkingHourCommandHandler(IRepository<WorkingHour> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateWorkingHourCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync( new WorkingHour()
			{
			 DoctorId = request.DoctorId,
			 DayOfWeek = request.DayOfWeek,	
			 StartTime = request.StartTime,
			 EndTime = request.EndTime,
			 IsOffDay = request.IsOffDay,
				
			});
		}
	}
}

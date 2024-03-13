using HospitalCmsSystem.Application.CQRS.Queries.WorkingHourQueries;
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
	public class GetWorkingHourByIdQueryHandler : IRequestHandler<GetWorkingHourByIdQuery, GetWorkingHourByIdQueryResult>
	{
		private readonly IRepository<WorkingHour> _repository;

		public GetWorkingHourByIdQueryHandler(IRepository<WorkingHour> repository)
		{
			_repository = repository;
		}

		public async Task<GetWorkingHourByIdQueryResult> Handle(GetWorkingHourByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetWorkingHourByIdQueryResult
			{
				Id = values.Id,
                DoctorId = values.DoctorId,
                DayOfWeek = values.DayOfWeek,
                StartTime = values.StartTime,
                EndTime = values.EndTime,
                IsOffDay = values.IsOffDay,
            };

		}
	}
}

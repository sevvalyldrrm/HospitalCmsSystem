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
	public class GetWorkingHourQueryHandler : IRequestHandler<GetWorkingHourQuery, List<GetWorkingHourQueryResult>>
	{
		private readonly IRepository<WorkingHour> _repository;

		public GetWorkingHourQueryHandler(IRepository<WorkingHour> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetWorkingHourQueryResult>> Handle(GetWorkingHourQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetWorkingHourQueryResult
            {
                DoctorId = x.DoctorId,
                DayOfWeek = x.DayOfWeek,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                IsOffDay = x.IsOffDay,
                Id = x.Id
			}).ToList();
		}
	}
}

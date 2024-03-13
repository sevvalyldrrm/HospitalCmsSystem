using HospitalCmsSystem.Application.CQRS.Queries.AppointmentManagerQueries;
using HospitalCmsSystem.Application.CQRS.Results.AppointmentManagerResults;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.AppointmentManagerHandlers
{
	public class GetAppointmentManagerQueryHandler : IRequestHandler<GetAppointmentManagerQuery, List<GetAppointmentManagerQueryResult>>
	{
		private readonly IRepository<AppointmentManager> _repository;

		public GetAppointmentManagerQueryHandler(IRepository<AppointmentManager> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetAppointmentManagerQueryResult>> Handle(GetAppointmentManagerQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetAppointmentManagerQueryResult
			{
                DoctorId = x.DoctorId,
                PatientId = x.PatientId,
                StartingTime = x.StartingTime,
                EndingTime = x.EndingTime,
                Status = x.Status,
                Id = x.Id
			}).ToList();
		}
	}
}

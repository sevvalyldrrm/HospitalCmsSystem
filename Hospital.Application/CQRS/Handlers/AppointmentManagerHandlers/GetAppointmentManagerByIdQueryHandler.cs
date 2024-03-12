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
	public class GetAppointmentManagerByIdQueryHandler : IRequestHandler<GetAppointmentManagerByIdQuery, GetAppointmentManagerByIdQueryResult>
	{
		private readonly IRepository<AppointmentManager> _repository;

		public GetAppointmentManagerByIdQueryHandler(IRepository<AppointmentManager> repository)
		{
			_repository = repository;
		}

		public async Task<GetAppointmentManagerByIdQueryResult> Handle(GetAppointmentManagerByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetAppointmentManagerByIdQueryResult
			{
				Id = values.Id,
                DoctorId = values.DoctorId,
                PatientId = values.PatientId,
                StartingTime = values.StartingTime,
                EndingTime = values.EndingTime,
                Status = values.Status,
            };

		}
	}
}

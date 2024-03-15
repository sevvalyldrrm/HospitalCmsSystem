using HospitalCmsSystem.Application.CQRS.Queries.PatientQueries;
using HospitalCmsSystem.Application.CQRS.Results.PatientResults;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.PatientHandlers
{
	public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, GetPatientByIdQueryResult>
	{
		private readonly IRepository<Patient> _repository;

		public GetPatientByIdQueryHandler(IRepository<Patient> repository)
		{
			_repository = repository;
		}

		public async Task<GetPatientByIdQueryResult> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetPatientByIdQueryResult
			{
				Id = values.Id,
                Diagnosis = values.Diagnosis,
                IsDischarged = values.IsDischarged,
                RoleId = values.RoleId,
				Name = values.Name,
            };

		}
	}
}

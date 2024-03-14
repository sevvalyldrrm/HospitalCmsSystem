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
	public class GetPatientQueryHandler : IRequestHandler<GetPatientQuery, List<GetPatientQueryResult>>
	{
		private readonly IRepository<Patient> _repository;

		public GetPatientQueryHandler(IRepository<Patient> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetPatientQueryResult>> Handle(GetPatientQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetPatientQueryResult
            {
                Diagnosis = x.Diagnosis,
                IsDischarged = x.IsDischarged,
                RoleId = x.RoleId,
                Id = x.Id
			}).ToList();
		}
	}
}

using HospitalCmsSystem.Application.CQRS.Queries.DoctorPatientQueries;
using HospitalCmsSystem.Application.CQRS.Results.DoctorPatientResults;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.DoctorPatientHandlers
{
	public class GetDoctorPatientQueryHandler : IRequestHandler<GetDoctorPatientQuery, List<GetDoctorPatientQueryResult>>
	{
		private readonly IRepository<DoctorPatient> _repository;

		public GetDoctorPatientQueryHandler(IRepository<DoctorPatient> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetDoctorPatientQueryResult>> Handle(GetDoctorPatientQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetDoctorPatientQueryResult
            {
                DoctorId = x.DoctorId,
                PatientId = x.PatientId,
                Id = x.Id
			}).ToList();
		}
	}
}

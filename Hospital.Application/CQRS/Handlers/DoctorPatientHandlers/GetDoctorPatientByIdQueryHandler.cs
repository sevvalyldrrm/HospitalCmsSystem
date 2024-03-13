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
	public class GetDoctorPatientByIdQueryHandler : IRequestHandler<GetDoctorPatientByIdQuery, GetDoctorPatientByIdQueryResult>
	{
		private readonly IRepository<DoctorPatient> _repository;

		public GetDoctorPatientByIdQueryHandler(IRepository<DoctorPatient> repository)
		{
			_repository = repository;
		}

		public async Task<GetDoctorPatientByIdQueryResult> Handle(GetDoctorPatientByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetDoctorPatientByIdQueryResult
			{
				Id = values.Id,
                DoctorId = values.DoctorId,
                PatientId = values.PatientId,
            };

		}
	}
}

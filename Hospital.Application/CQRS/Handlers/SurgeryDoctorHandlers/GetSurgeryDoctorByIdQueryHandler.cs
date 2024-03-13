using HospitalCmsSystem.Application.CQRS.Queries.SurgeryDoctorQueries;
using HospitalCmsSystem.Application.CQRS.Results.SurgeryDoctorResults;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.SurgeryDoctorHandlers
{
	public class GetSurgeryDoctorByIdQueryHandler : IRequestHandler<GetSurgeryDoctorByIdQuery, GetSurgeryDoctorByIdQueryResult>
	{
		private readonly IRepository<SurgeryDoctor> _repository;

		public GetSurgeryDoctorByIdQueryHandler(IRepository<SurgeryDoctor> repository)
		{
			_repository = repository;
		}

		public async Task<GetSurgeryDoctorByIdQueryResult> Handle(GetSurgeryDoctorByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetSurgeryDoctorByIdQueryResult
			{
				Id = values.Id,
                DoctorId = values.DoctorId,
                SurgeryId = values.SurgeryId,
            };

		}
	}
}

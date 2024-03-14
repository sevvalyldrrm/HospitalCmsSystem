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
	public class GetSurgeryDoctorQueryHandler : IRequestHandler<GetSurgeryDoctorQuery, List<GetSurgeryDoctorQueryResult>>
	{
		private readonly IRepository<SurgeryDoctor> _repository;

		public GetSurgeryDoctorQueryHandler(IRepository<SurgeryDoctor> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetSurgeryDoctorQueryResult>> Handle(GetSurgeryDoctorQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetSurgeryDoctorQueryResult
            {
                DoctorId = x.DoctorId,
                SurgeryId = x.SurgeryId,
                Id = x.Id
			}).ToList();
		}
	}
}

using HospitalCmsSystem.Application.CQRS.Queries.SurgeryQueries;
using HospitalCmsSystem.Application.CQRS.Results.SurgeryResults;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.SurgeryHandlers
{
	public class GetSurgeryQueryHandler : IRequestHandler<GetSurgeryQuery, List<GetSurgeryQueryResult>>
	{
		private readonly IRepository<Surgery> _repository;

		public GetSurgeryQueryHandler(IRepository<Surgery> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetSurgeryQueryResult>> Handle(GetSurgeryQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetSurgeryQueryResult
            {
                PatientId = x.PatientId,
                DepartmentId = x.DepartmentId,
                SurgeryDate = x.SurgeryDate,
                Id = x.Id
			}).ToList();
		}
	}
}

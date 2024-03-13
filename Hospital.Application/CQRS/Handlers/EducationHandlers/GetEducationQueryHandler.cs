using HospitalCmsSystem.Application.CQRS.Queries.EducationQueries;
using HospitalCmsSystem.Application.CQRS.Results.EducationResults;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.EducationHandlers
{
	public class GetEducationQueryHandler : IRequestHandler<GetEducationQuery, List<GetEducationQueryResult>>
	{
		private readonly IRepository<Education> _repository;

		public GetEducationQueryHandler(IRepository<Education> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetEducationQueryResult>> Handle(GetEducationQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetEducationQueryResult
            {
                Year = x.Year,
                University = x.University,
                Explanation = x.Explanation,
                DoctorId = x.DoctorId,
                Id = x.Id
			}).ToList();
		}
	}
}

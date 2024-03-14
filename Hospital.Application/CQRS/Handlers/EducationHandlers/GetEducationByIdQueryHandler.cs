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
	public class GetEducationByIdQueryHandler : IRequestHandler<GetEducationByIdQuery, GetEducationByIdQueryResult>
	{
		private readonly IRepository<Education> _repository;

		public GetEducationByIdQueryHandler(IRepository<Education> repository)
		{
			_repository = repository;
		}

		public async Task<GetEducationByIdQueryResult> Handle(GetEducationByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetEducationByIdQueryResult
			{
				Id = values.Id,
                Year = values.Year,
                University = values.University,
                Explanation = values.Explanation,
                DoctorId = values.DoctorId,
            };

		}
	}
}

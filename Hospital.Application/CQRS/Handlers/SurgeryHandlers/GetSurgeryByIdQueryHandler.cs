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
	public class GetSurgeryByIdQueryHandler : IRequestHandler<GetSurgeryByIdQuery, GetSurgeryByIdQueryResult>
	{
		private readonly IRepository<Surgery> _repository;

		public GetSurgeryByIdQueryHandler(IRepository<Surgery> repository)
		{
			_repository = repository;
		}

		public async Task<GetSurgeryByIdQueryResult> Handle(GetSurgeryByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetSurgeryByIdQueryResult
			{
				Id = values.Id,
                PatientId = values.PatientId,
                DepartmentId = values.DepartmentId,
                SurgeryDate = values.SurgeryDate,
            };

		}
	}
}

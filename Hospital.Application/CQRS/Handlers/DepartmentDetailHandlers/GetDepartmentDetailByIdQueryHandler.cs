using HospitalCmsSystem.Application.CQRS.Queries.DepartmentDetailQueries;
using HospitalCmsSystem.Application.CQRS.Results.DepartmentDetailResults;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.DepartmentDetailHandlers
{
	public class GetDepartmentDetailByIdQueryHandler : IRequestHandler<GetDepartmentDetailByIdQuery, GetDepartmentDetailByIdQueryResult>
	{
		private readonly IRepository<DepartmentDetail> _repository;

		public GetDepartmentDetailByIdQueryHandler(IRepository<DepartmentDetail> repository)
		{
			_repository = repository;
		}

		public async Task<GetDepartmentDetailByIdQueryResult> Handle(GetDepartmentDetailByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetDepartmentDetailByIdQueryResult
			{
				Id = values.Id,
                Title = values.Title,
                DescriptionLong = values.DescriptionLong,
                DescriptionShort = values.DescriptionShort,
                DepartmentId = values.DepartmentId,
            };

		}
	}
}

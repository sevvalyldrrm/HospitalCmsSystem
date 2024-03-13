using HospitalCmsSystem.Application.CQRS.Queries.DepartmentQueries;
using HospitalCmsSystem.Application.CQRS.Results.DepartmentResults;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.DepartmentHandlers
{
	public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, GetDepartmentByIdQueryResult>
	{
		private readonly IRepository<Department> _repository;

		public GetDepartmentByIdQueryHandler(IRepository<Department> repository)
		{
			_repository = repository;
		}

		public async Task<GetDepartmentByIdQueryResult> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetDepartmentByIdQueryResult
			{
				Id = values.Id,
                Name = values.Name,
                Description = values.Description,
                DepartmentDetailsId = values.DepartmentDetailsId,
                ImagePath = values.ImagePath,
            };

		}
	}
}

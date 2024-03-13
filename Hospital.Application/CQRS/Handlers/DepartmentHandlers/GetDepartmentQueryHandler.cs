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
	public class GetDepartmentQueryHandler : IRequestHandler<GetDepartmentQuery, List<GetDepartmentQueryResult>>
	{
		private readonly IRepository<Department> _repository;

		public GetDepartmentQueryHandler(IRepository<Department> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetDepartmentQueryResult>> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetDepartmentQueryResult
            {
                Name = x.Name,
                Description = x.Description,
                DepartmentDetailsId = x.DepartmentDetailsId,
                ImagePath = x.ImagePath,
                Id = x.Id
			}).ToList();
		}
	}
}

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
	public class GetDepartmentDetailQueryHandler : IRequestHandler<GetDepartmentDetailQuery, List<GetDepartmentDetailQueryResult>>
	{
		private readonly IRepository<DepartmentDetail> _repository;

		public GetDepartmentDetailQueryHandler(IRepository<DepartmentDetail> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetDepartmentDetailQueryResult>> Handle(GetDepartmentDetailQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetDepartmentDetailQueryResult
            {
                Title = x.Title,
                DescriptionLong = x.DescriptionLong,
                DescriptionShort = x.DescriptionShort,
                DepartmentId = x.DepartmentId,
                Id = x.Id
			}).ToList();
		}
	}
}

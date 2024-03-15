using HospitalCmsSystem.Application.CQRS.Queries.AdminQueries;
using HospitalCmsSystem.Application.CQRS.Results.AdminResults;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.AdminHandlers
{
	public class GetAdminQueryHandler : IRequestHandler<GetAdminQuery, List<GetAdminQueryResult>>
	{
		private readonly IRepository<Admin> _repository;

		public GetAdminQueryHandler(IRepository<Admin> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetAdminQueryResult>> Handle(GetAdminQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetAdminQueryResult
            {
                GitHubAcc = x.GitHubAcc,
				Name = x.Name,
                Id = x.Id
			}).ToList();
		}
	}
}

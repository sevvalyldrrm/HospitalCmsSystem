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
	public class GetAdminByIdQueryHandler : IRequestHandler<GetAdminByIdQuery, GetAdminByIdQueryResult>
	{
		private readonly IRepository<Admin> _repository;

		public GetAdminByIdQueryHandler(IRepository<Admin> repository)
		{
			_repository = repository;
		}

		public async Task<GetAdminByIdQueryResult> Handle(GetAdminByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetAdminByIdQueryResult
			{
				Id = values.Id,
				Name = values.Name,
                GitHubAcc = values.GitHubAcc,
            };

		}
	}
}

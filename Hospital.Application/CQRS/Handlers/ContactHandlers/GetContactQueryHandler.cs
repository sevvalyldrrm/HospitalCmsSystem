using HospitalCmsSystem.Application.CQRS.Queries.ContactQueries;
using HospitalCmsSystem.Application.CQRS.Results.ContactResults;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.ContactHandlers
{
	public class GetContactQueryHandler : IRequestHandler<GetContactQuery, List<GetContactQueryResult>>
	{
		private readonly IRepository<Contact> _repository;

		public GetContactQueryHandler(IRepository<Contact> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetContactQueryResult>> Handle(GetContactQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetContactQueryResult
            {
                FullName = x.FullName,
                Email = x.Email,
                Phone = x.Phone,
                Title = x.Title,
                Message = x.Message,
                Id = x.Id
			}).ToList();
		}
	}
}

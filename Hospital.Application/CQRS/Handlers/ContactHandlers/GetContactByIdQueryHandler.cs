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
	public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, GetContactByIdQueryResult>
	{
		private readonly IRepository<Contact> _repository;

		public GetContactByIdQueryHandler(IRepository<Contact> repository)
		{
			_repository = repository;
		}

		public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetContactByIdQueryResult
			{
				Id = values.Id,
                FullName = values.FullName,
                Email = values.Email,
                Phone = values.Phone,
                Title = values.Title,
                Message = values.Message,
            };

		}
	}
}

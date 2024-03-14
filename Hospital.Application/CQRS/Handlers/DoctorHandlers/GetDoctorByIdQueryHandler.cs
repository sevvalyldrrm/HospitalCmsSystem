using HospitalCmsSystem.Application.CQRS.Queries.DoctorQueries;
using HospitalCmsSystem.Application.CQRS.Results.DoctorResults;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.DoctorHandlers
{
	public class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByIdQuery, GetDoctorByIdQueryResult>
	{
		private readonly IRepository<Doctor> _repository;

		public GetDoctorByIdQueryHandler(IRepository<Doctor> repository)
		{
			_repository = repository;
		}

		public async Task<GetDoctorByIdQueryResult> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetDoctorByIdQueryResult
			{
				Id = values.Id,
                Speacialty = values.Speacialty,
                DepartmentId = values.DepartmentId,
                RoleId = values.RoleId,
                IntroductionId = values.IntroductionId,
                DocFacebook = values.DocFacebook,
                DocX = values.DocX,
                DocPinterest = values.DocPinterest,
                DocSkype = values.DocSkype,
                DocLinkedIn = values.DocLinkedIn,
                DocTitle = values.DocTitle,
            };

		}
	}
}

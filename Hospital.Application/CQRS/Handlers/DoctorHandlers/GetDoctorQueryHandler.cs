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
	public class GetDoctorQueryHandler : IRequestHandler<GetDoctorQuery, List<GetDoctorQueryResult>>
	{
		private readonly IRepository<Doctor> _repository;

		public GetDoctorQueryHandler(IRepository<Doctor> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetDoctorQueryResult>> Handle(GetDoctorQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetDoctorQueryResult
            {
				Name = x.Name,
                Specialty = x.Specialty,
                DepartmentId = x.DepartmentId,
                IntroductionId = x.IntroductionId,
                DocFacebook = x.DocFacebook,
                DocX = x.DocX,
                DocPinterest = x.DocPinterest,
                DocSkype = x.DocSkype,
                DocLinkedIn = x.DocLinkedIn,
                DocTitle = x.DocTitle,
                Id = x.Id
			}).ToList();
		}
	}
}

using HospitalCmsSystem.Application.CQRS.Queries.IntroductionQueries;
using HospitalCmsSystem.Application.CQRS.Results.IntroductionResults;
using HospitalCmsSystem.Application.Interfaces;
using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.IntroductionHandlers
{
	public class GetIntroductionQueryHandler : IRequestHandler<GetIntroductionQuery, List<GetIntroductionQueryResult>>
	{
		private readonly IRepository<Introduction> _repository;

		public GetIntroductionQueryHandler(IRepository<Introduction> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetIntroductionQueryResult>> Handle(GetIntroductionQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetIntroductionQueryResult
            {
                MySkills = x.MySkills,
                Description = x.Description,
                DoctorId = x.DoctorId,
                WorkingHour = x.WorkingHour,
                Id = x.Id
			}).ToList();
		}
	}
}

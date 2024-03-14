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
	public class GetIntroductionByIdQueryHandler : IRequestHandler<GetIntroductionByIdQuery, GetIntroductionByIdQueryResult>
	{
		private readonly IRepository<Introduction> _repository;

		public GetIntroductionByIdQueryHandler(IRepository<Introduction> repository)
		{
			_repository = repository;
		}

		public async Task<GetIntroductionByIdQueryResult> Handle(GetIntroductionByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetIntroductionByIdQueryResult
			{
				Id = values.Id,
                MySkills = values.MySkills,
                Description = values.Description,
                DoctorId = values.DoctorId,
                WorkingHour = values.WorkingHour,
            };

		}
	}
}

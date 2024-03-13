using HospitalCmsSystem.Application.CQRS.Results.IntroductionResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Queries.IntroductionQueries
{
	public class GetIntroductionByIdQuery : IRequest<GetIntroductionByIdQueryResult>
	{
		public int Id { get; set; }

        public GetIntroductionByIdQuery(int id)
        {
            Id = id;
        }
    }
}

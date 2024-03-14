using HospitalCmsSystem.Application.CQRS.Results.WorkingHourResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Queries.WorkingHourQueries
{
	public class GetWorkingHourByIdQuery : IRequest<GetWorkingHourByIdQueryResult>
	{
		public int Id { get; set; }

        public GetWorkingHourByIdQuery(int id)
        {
            Id = id;
        }
    }
}

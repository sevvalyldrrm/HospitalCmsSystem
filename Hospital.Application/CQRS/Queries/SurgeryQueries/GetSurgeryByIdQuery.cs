using HospitalCmsSystem.Application.CQRS.Results.SurgeryResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Queries.SurgeryQueries
{
	public class GetSurgeryByIdQuery : IRequest<GetSurgeryByIdQueryResult>
	{
		public int Id { get; set; }

        public GetSurgeryByIdQuery(int id)
        {
            Id = id;
        }
    }
}

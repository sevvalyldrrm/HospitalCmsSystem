using HospitalCmsSystem.Application.CQRS.Results.DepartmentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Queries.DepartmentQueries
{
    public class GetDepartmentWithDetailsByIdQuery : IRequest<GetDepartmentWithDetailsByIdQueryResult>
    {
        public GetDepartmentWithDetailsByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; } 

    }
}

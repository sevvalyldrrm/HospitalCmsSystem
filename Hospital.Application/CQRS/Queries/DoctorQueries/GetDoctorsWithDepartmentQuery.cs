using HospitalCmsSystem.Application.CQRS.Results.DoctorResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Queries.DoctorQueries
{
    public class GetDoctorsWithDepartmentQuery : IRequest<List<GetDoctorsWithDepartmentQueryResult>>
    {

    }
}

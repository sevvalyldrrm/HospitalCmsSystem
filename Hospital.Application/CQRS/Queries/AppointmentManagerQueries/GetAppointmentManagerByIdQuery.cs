using HospitalCmsSystem.Application.CQRS.Results.AppointmentManagerResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Queries.AppointmentManagerQueries
{
    public class GetAppointmentManagerByIdQuery : IRequest<GetAppointmentManagerByIdQueryResult>
    {
        public int Id { get; set; }

        public GetAppointmentManagerByIdQuery(int id)
        {
            Id = id;
        }
    }
}

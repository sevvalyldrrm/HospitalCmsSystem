using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.AppointmentManagerCommands
{
    public class RemoveAppointmentManagerCommand : IRequest
    {
        public int Id { get; set; }
        public RemoveAppointmentManagerCommand(int id)
        {
            Id = id;
        }
    }
}

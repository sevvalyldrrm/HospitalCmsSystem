using HospitalCmsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.AppointmentManagerCommands
{
    public class UpdateAppointmentManagerCommand : IRequest
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }

        public int PatientId { get; set; }
        public DateTime StartingTime { get; set; }
        public DateTime EndingTime { get; set; }
        public AppointmentStatus Status { get; set; }
    }
}

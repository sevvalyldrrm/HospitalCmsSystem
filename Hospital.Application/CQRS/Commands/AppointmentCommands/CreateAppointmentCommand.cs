using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.AppointmentCommands
{
    public class CreateAppointmentCommand : IRequest
    {
        public int DepartmentId { get; set; }

        public int DoctorId { get; set; }

        public int PatientId { get; set; }


        public string Email { get; set; }

        public string FullName { get; set; }

        public string Phone { get; set; }

        public string Message { get; set; }

        public DateTime AppointmentDate { get; set; }
        public int AppointmentManagerId { get; set; }
    }
}

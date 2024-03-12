using HospitalCmsSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Results.AppointmentResults
{
    public class GetAppointmentQueryResult : BaseResult
    {

        public int DepartmentId { get; set; }

        public string DoctorId { get; set; }

        public string PatientId { get; set; }


        public string Email { get; set; }

        public string FullName { get; set; }

        public string Phone { get; set; }

        public string Message { get; set; }

        public DateTime AppointmentDate { get; set; }
        public int AppointmentManagerId { get; set; }
    }
}

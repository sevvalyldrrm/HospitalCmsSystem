
using HospitalCmsSystem.Domain.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HospitalCmsSystem.Domain.Entities
{
    public class AppointmentManager : BaseEntity
	{
        
        [ForeignKey(nameof(Doctor.Id))]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [ForeignKey(nameof(Patient.Id))]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public DateTime StartingTime { get; set; }
        public DateTime EndingTime { get; set; }
        public AppointmentStatus Status { get; set; }

        public ICollection<WorkingHour> WorkingHours { get; set; }=new List<WorkingHour>();
    }
    public enum AppointmentStatus
    {
        Pending = 1,
        Confirmed = 2,
        Completed = 3,
        Cancelled = 4
    }
}



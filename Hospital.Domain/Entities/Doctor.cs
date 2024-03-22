using HospitalCmsSystem.Domain.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Domain.Entities
{
	public class Doctor : BaseEntity
	{
        public string Name { get; set; }

		public string Specialty { get; set; }

        [ForeignKey(nameof(AppUser.Id))]
        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public ICollection<DoctorPatient> DoctorPatients { get; set; }

        [ForeignKey(nameof(Department.Id))]
		public int DepartmentId { get; set; }

		public Department Department { get; set; }

		[ForeignKey(nameof(Introduction.Id))]
		public int IntroductionId {  get; set; }

        public Introduction Introduction { get; set; }

        public ICollection<SurgeryDoctor> SurgeryDoctors { get; set; }=new List<SurgeryDoctor>();
        public virtual ICollection<WorkingHour> WorkingHours { get; set; }=new List<WorkingHour>();
        public virtual ICollection<Appointment> Appointments { get; set; }=new List<Appointment>();
        public virtual ICollection<Education> Educations { get; set; }=new List<Education>();

        public string ?DocFacebook { get; set; }
        public string ?DocX { get; set; }
        public string ?DocPinterest   { get; set; }
        public string ?DocSkype { get; set; }        
        public string ?DocLinkedIn { get; set; }

        public string ?DocTitle { get; set; }

        

    }
}

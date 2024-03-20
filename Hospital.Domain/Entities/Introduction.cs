using HospitalCmsSystem.Domain.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Domain.Entities
{
    public class Introduction : BaseEntity
	{
        //Doctor Single

        [ForeignKey(nameof(Doctor.Id))]
        public int DoctorId {  get; set; }
        public Doctor Doctor { get; set; }
        public string Description { get; set; }
        public string? MySkills { get; set; }

        [NotMapped]
        public virtual ICollection<string> ExpertisesAreas { get; set; }=new List<string>();
        public ICollection<Education> Educations { get; set; }= new List<Education>();
        public WorkingHour WorkingHour { get; set; } //Make appointment'teki doktora uygun çalışma saatleri
        [ForeignKey(nameof(WorkingHour.Id))]
        public int WorkingHourId { get; set; }

       
    }
}

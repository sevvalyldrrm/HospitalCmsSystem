using HospitalCmsSystem.Domain.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Domain.Entities
{
    public class SurgeryDoctor : BaseEntity
    {
        [ForeignKey(nameof(Doctor.Id))]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [ForeignKey(nameof(Surgery.Id))]
        public int SurgeryId { get; set; }
        public Surgery Surgery { get; set; }
    }

}

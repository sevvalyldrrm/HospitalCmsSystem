using HospitalCmsSystem.Domain.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Domain.Entities
{
    public class Education : BaseEntity
	{
        //Doctor's Education
        public string Year { get; set; }

        public string University { get; set; }
        public string ?Explanation { get; set; }

        [ForeignKey(nameof(Doctor.Id))]
        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }

    }
}

﻿using HospitalCmsSystem.Domain.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HospitalCmsSystem.Domain.Entities
{
    public class Surgery : BaseEntity
    {
        [ForeignKey(nameof(Patient.Id))]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }        

        [ForeignKey(nameof(Department.Id))]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<SurgeryDoctor> SurgeryDoctors { get; set; }=new List<SurgeryDoctor>();

        public DateTime SurgeryDate { get; set; }


    }
}

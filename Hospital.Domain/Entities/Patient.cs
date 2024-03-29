﻿using HospitalCmsSystem.Domain.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Domain.Entities
{
	public class Patient : BaseEntity
	{
        public string Name { get; set; }
        public string Diagnosis {  get; set; }

		public bool IsDischarged { get; set; }

        [ForeignKey(nameof(AppUser.Id))]
        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public ICollection<DoctorPatient> DoctorPatients { get; set; }=new List<DoctorPatient>();
        public ICollection<Appointment> Appointments { get; set; }= new List<Appointment>();
        public ICollection<Surgery> Surgeries { get; set; }=new List<Surgery>();

    }
}

﻿using HospitalCmsSystem.Domain.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Domain.Entities
{
	public class Appointment : BaseEntity
	{
        [ForeignKey(nameof(Department.Id))]
        public int DepartmentId { get; set; }

		public Department Department { get; set; }

        [ForeignKey(nameof(Doctor.Id))]
        public int DoctorId { get; set; }

		public Doctor Doctor { get; set; }

        [ForeignKey(nameof(Patient.Id))]
        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        public string Email { get; set;}

		public string FullName { get; set;}

		public string Phone {  get; set;}

		public string Message {  get; set;}

        [Required]
        public DateTime AppointmentDate { get; set; }

		[ForeignKey(nameof(AppointmentManager.Id))]
		public int AppointmentManagerId { get; set; }
		public AppointmentManager AppointmentManager { get; set; }
        
    }
}

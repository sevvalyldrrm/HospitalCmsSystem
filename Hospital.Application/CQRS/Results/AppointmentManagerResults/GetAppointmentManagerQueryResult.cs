﻿using HospitalCmsSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Results.AppointmentManagerResults
{
    public class GetAppointmentManagerQueryResult : BaseResult
    {
       
        public int DoctorId { get; set; }
      
        public int PatientId { get; set; }
        public DateTime StartingTime { get; set; }
        public DateTime EndingTime { get; set; }
        public AppointmentStatus Status { get; set; }

    }
}

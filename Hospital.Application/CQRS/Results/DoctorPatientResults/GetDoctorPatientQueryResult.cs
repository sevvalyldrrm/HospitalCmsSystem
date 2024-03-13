using HospitalCmsSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Results.DoctorPatientResults
{
    public class GetDoctorPatientQueryResult : BaseResult
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
    }
}

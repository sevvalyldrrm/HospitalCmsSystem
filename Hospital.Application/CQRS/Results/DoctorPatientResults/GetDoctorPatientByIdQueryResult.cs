using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Results.DoctorPatientResults
{
    public class GetDoctorPatientByIdQueryResult : BaseResult
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
    }
}

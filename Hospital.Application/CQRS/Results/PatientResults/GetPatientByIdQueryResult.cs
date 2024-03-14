using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Results.PatientResults
{
    public class GetPatientByIdQueryResult : BaseResult
    {
        public string Diagnosis { get; set; }
        public bool IsDischarged { get; set; }
        public int RoleId { get; set; }
    }
}

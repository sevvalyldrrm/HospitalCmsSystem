using HospitalCmsSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Results.PatientResults
{
    public class GetPatientQueryResult : BaseResult
    {
        public string Name { get; set; }
        public string Diagnosis { get; set; }
        public bool IsDischarged { get; set; }

    }
}

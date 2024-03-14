using HospitalCmsSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Results.SurgeryResults
{
    public class GetSurgeryQueryResult : BaseResult
    {
        public int PatientId { get; set; }
        public int DepartmentId { get; set; }
        public DateTime SurgeryDate { get; set; }
    }
}

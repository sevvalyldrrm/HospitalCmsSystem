using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Results.SurgeryDoctorResults
{
    public class GetSurgeryDoctorByIdQueryResult : BaseResult
    {
        public int DoctorId { get; set; }

        public int SurgeryId { get; set; }
    }
}

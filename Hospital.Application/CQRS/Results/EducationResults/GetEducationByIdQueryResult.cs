using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Results.EducationResults
{
    public class GetEducationByIdQueryResult : BaseResult
    {
        public string Year { get; set; }

        public string University { get; set; }

        public string Explanation { get; set; }

        public int DoctorId { get; set; }
    }
}

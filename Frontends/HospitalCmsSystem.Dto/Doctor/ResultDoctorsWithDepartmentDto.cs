using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Dto.Doctor
{
    public class ResultDoctorsWithDepartmentDto
    {
            public string name { get; set; }
            public string Specialty { get; set; }
            public int departmentId { get; set; }
            public int introductionId { get; set; }
            public string docFacebook { get; set; }
            public string docX { get; set; }
            public string docPinterest { get; set; }
            public string docSkype { get; set; }
            public string docLinkedIn { get; set; }
            public string docTitle { get; set; }
            public string departmentName { get; set; }
            public string departmentDescription { get; set; }
            public int departmentDetailsId { get; set; }
            public string departmentImagePath { get; set; }
            public int id { get; set; }

    }
}

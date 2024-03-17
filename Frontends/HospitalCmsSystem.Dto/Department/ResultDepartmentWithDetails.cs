using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Dto.Department
{
    public class ResultDepartmentWithDetails
    {
            public string name { get; set; }
            public string description { get; set; }
            public string imagePath { get; set; }
            public int departmentDetailsId { get; set; }
            public string title { get; set; }
            public string descriptionShort { get; set; }
            public string descriptionLong { get; set; }
            public int id { get; set; }

    }
}

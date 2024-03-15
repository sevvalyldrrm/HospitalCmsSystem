using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Dto.Department
{
	public class ResultDepartmentDto
	{
			public int id { get; set; }
			public string name { get; set; }
			public string description { get; set; }
			public int departmentDetailsId { get; set; }
			public string imagePath { get; set; }

	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Results.DepartmentDetailResults
{
    public class GetDepartmentDetailQueryResult : BaseResult
    {
        public string Title { get; set; }
        public string DescriptionShort { get; set; }
        public string DescriptionLong { get; set; }
        public int DepartmentId { get; set; }
    }
}

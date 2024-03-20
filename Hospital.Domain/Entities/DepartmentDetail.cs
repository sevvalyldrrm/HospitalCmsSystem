using HospitalCmsSystem.Domain.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Domain.Entities
{
    public class DepartmentDetail : BaseEntity
	{

        //Department Single
    
        public string Title { get; set; }
        public string DescriptionShort { get; set; }
        public string DescriptionLong { get; set; }
        [NotMapped]
        public virtual ICollection<string> DepartmentFeatures { get; set; }

        [ForeignKey(nameof(Department.Id))]
        public int DepartmentId { get; set; }
        public Department Departments { get; set; }

    }
}

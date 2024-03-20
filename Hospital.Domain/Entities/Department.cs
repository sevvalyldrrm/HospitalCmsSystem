using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using HospitalCmsSystem.Domain.Entities.BaseEntities;

namespace HospitalCmsSystem.Domain.Entities
{
	public class Department : BaseEntity
	{

		[DisplayName("İsim")]
		[Required(ErrorMessage = "{0} boş geçilemez")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "{0} alanı en az {2} en fazla {1} karakter olabilir")]
        public string Name { get; set; }

		[DisplayName("Açıklama")]
		[StringLength(200, ErrorMessage = "{0} alanı en fazla {1} karakter olabilir")]
		public string Description { get; set; } //DepartmentHTML'de kullanılacak

		[ForeignKey(nameof(DepartmentDetail.Id))]
		public int DepartmentDetailsId { get; set; }
        public DepartmentDetail DepartmentDetails { get; set; }
        public string? ImagePath { get; set; }

        public ICollection<DepartmentBlog> DepartmentBlogs { get; set; }= new List<DepartmentBlog>();

        public ICollection<Doctor> Doctors { get; set; }=new List<Doctor>();

      
    }
}

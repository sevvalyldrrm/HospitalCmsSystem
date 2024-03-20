using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalCmsSystem.Domain.Entities.BaseEntities;


namespace HospitalCmsSystem.Domain.Entities
{
	public class DepartmentBlog : BaseEntity
	{
		//Blog Single sayfasındaki "Categories" kısmı için yazıldı. Biz burada blog post'larının hangi departman tarafından yazıldığını belirtmek istiyoruz.

		[Required(ErrorMessage = "{0} boş geçilemez")]
        [ForeignKey(nameof(Department.Id))]
        public int DepartmentId { get; set; }

		public Department Department { get; set; }

		[Required(ErrorMessage = "{0} boş geçilemez")]
        [ForeignKey(nameof(Blog.Id))]
        public int BlogId { get; set; }

		public Blog Blog {  get; set; }

		
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalCmsSystem.Domain.Entities.BaseEntities;

namespace HospitalCmsSystem.Domain.Entities
{
	public class AppUser : BaseEntitiy
    {
        [StringLength(100, MinimumLength = 2, ErrorMessage = "{0} alanı en az {2} en fazla {1} karakter olabilir")]
        [DisplayName("İsim")]
		public string? FullName { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "{0} alanı en az {2} en fazla {1} karakter olabilir")]
        [DisplayName("Şehir")]
		public string? City { get; set; }

        [StringLength(50, ErrorMessage = "Telefon numarası en fazla {1} karakter olabilir")]
        [DisplayName("Telefon")]
        public string? Phone { get; set; }

        [EmailAddress(ErrorMessage = "Geçersiz E-Mail adresi")]
        [DisplayName("E-Mail")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "{0} alanı en az {2} en fazla {1} karakter olabilir")]
        [DisplayName("Kullanıcı Adı")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "{0} alanı en az {2} en fazla {1} karakter olabilir")]
        [DataType(DataType.Password)]
        [DisplayName("Şifre")]
        public string? Password { get; set; }

        public bool IsActive { get; set; } = true;
        public string? ImagePath { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }

		public virtual ICollection<AppUserRole> UserRoles { get; set; }

	}
}

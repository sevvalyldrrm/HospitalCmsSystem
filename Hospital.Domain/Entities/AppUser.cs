using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalCmsSystem.Domain.Entities.BaseEntities;
using Microsoft.AspNetCore.Identity;

namespace HospitalCmsSystem.Domain.Entities
{
	public class AppUser :IdentityUser<int>
    {
        [StringLength(100, MinimumLength = 2, ErrorMessage = "{0} alanı en az {2} en fazla {1} karakter olabilir")]
        [DisplayName("İsim")]
		public string? FullName { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "{0} alanı en az {2} en fazla {1} karakter olabilir")]
        [DisplayName("Şehir")]
		public string? City { get; set; } 
        public bool IsActive { get; set; } = true;
        public string? ImagePath { get; set; } 
		

	}
}

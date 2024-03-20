using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Dto.RoleManagement
{
    public class UserRoleUpdateModel
    {
        public int UserId { get; set; } // UserID'yi int türünde tanımlıyoruz.
        public string Role { get; set; } // Rol ismini içeren bir string.
    }
}

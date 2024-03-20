using HospitalCmsSystem.Domain.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Domain.Entities
{
    public class Admin : BaseEntity
	{
        public string Name { get; set; }

        public string GitHubAcc { get; set; }

        [ForeignKey(nameof(AppUser.Id))]
        public int AppUserId {  get; set; }

        public AppUser AppUser { get; set; }

        

        
    }
}

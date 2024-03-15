using HospitalCmsSystem.Domain.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Domain.Entities
{
    public class Admin : BaseEntitiy
	{
        public string Name { get; set; }

        public string GitHubAcc { get; set; }
    }
}

﻿using HospitalCmsSystem.Domain.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Domain.Entities
{
	public class AppUserRole : BaseEntitiy
	{
		public virtual AppUser User { get; set; }
		public virtual AppRole Role { get; set; }
	}
}

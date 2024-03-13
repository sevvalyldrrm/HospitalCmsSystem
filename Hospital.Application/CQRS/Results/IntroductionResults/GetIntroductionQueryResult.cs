﻿using HospitalCmsSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Results.IntroductionResults
{
    public class GetIntroductionQueryResult : BaseResult
    {
        public int DoctorId { get; set; }
        public string Description { get; set; }
        public string MySkills { get; set; }
        public WorkingHour WorkingHour { get; set; }
    }
}

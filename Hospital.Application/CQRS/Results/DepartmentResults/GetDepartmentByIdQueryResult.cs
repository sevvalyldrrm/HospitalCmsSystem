using HospitalCmsSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Results.DepartmentResults
{
    public class GetDepartmentByIdQueryResult : BaseResult
    {
      
        public string Name { get; set; }
        public string Description { get; set; }
        public int DepartmentDetailsId { get; set; }
        public string? ImagePath { get; set; }

    }
}

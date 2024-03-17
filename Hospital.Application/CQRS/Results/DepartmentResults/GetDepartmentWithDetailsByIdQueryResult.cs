using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalCmsSystem.Domain.Entities;

namespace HospitalCmsSystem.Application.CQRS.Results.DepartmentResults
{
    public class GetDepartmentWithDetailsByIdQueryResult : BaseResult
    {
        public string Name { get; set; }
        public string Description { get; set; } //DepartmentHTML'de kullanılacak
        public string? ImagePath { get; set; }
        public int DepartmentDetailsId { get; set; }

        // 

        public string Title { get; set; }
        public string DescriptionShort { get; set; }
        public string DescriptionLong { get; set; }


    }
}

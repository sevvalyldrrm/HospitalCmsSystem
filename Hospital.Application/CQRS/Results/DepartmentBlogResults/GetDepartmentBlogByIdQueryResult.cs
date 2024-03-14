using HospitalCmsSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Results.DepartmentBlogResults
{
    public class GetDepartmentBlogByIdQueryResult : BaseResult
    {
        public int DepartmentId { get; set; }

        public int BlogId { get; set; }
    }
}

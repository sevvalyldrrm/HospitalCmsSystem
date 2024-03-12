using HospitalCmsSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Results.BlogCommentResults
{
    public class GetBlogCommentByIdQueryResult : BaseResult
    {
        public int BlogId { get; set; }
        public string Comment { get; set; }
        public bool IsActive { get; set; }
        public int AppUserId { get; set; }
    }
}

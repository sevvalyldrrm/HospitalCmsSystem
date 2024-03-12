using HospitalCmsSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Results.BlogResults
{
    public class GetBlogByIdQueryResult : BaseResult
    {
       
        public int AppUserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Tag { get; set; }

    }
}

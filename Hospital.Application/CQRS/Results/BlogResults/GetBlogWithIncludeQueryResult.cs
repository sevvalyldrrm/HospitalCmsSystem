using HospitalCmsSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalCmsSystem.Application.CQRS.Results.BlogCommentResults;
using HospitalCmsSystem.Application.CQRS.Results.BlogImageResults;

namespace HospitalCmsSystem.Application.CQRS.Results.BlogResults
{
    public class GetBlogWithIncludeQueryResult : BaseResult
    {

        public int AppUserId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
        public string Tag { get; set; }

        public List<string> Categories { get; set; }

        //

        //public int BlogId { get; set; }

        public List<GetBlogCommentQueryResult> Comment { get; set; }

        public bool IsActive { get; set; }

        //

        public List<GetBlogImageQueryResult> ImagePath { get; set; }

        //
       // public int DepartmentId { get; set; }

        //

       // public string Name { get; set; }

       // public string Description { get; set; } 
       // public int DepartmentDetailsId { get; set; }
        //
        //public List<GetAppUserQueryResult>

        

    }

}

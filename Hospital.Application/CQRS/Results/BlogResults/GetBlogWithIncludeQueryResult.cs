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
    public class GetBlogWithIncludeQueryResult 
    {
        //blogcomment
        public List<GetBlogCommentByIncludeQueryResult> Comment { get; set; }

        //public int BlogCommentId {  get; set; }

        //public bool IsActive {  get; set; }

        //blog
        public int BlogId {  get; set; }
        public List<string> Categories { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }
        public List<string> Tags { get; set; }

       //blogimage

        //public int BlogImageId {  get; set; }
        public List<GetBlogImageByIncludeQueryResult> ImagePath { get; set; }

        

        

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Results.BlogCommentResults
{
    public class GetBlogCommentByIncludeQueryResult 
    {
        public int BlogCommentId { get; set; }   
        public string Comment { get; set; }
        public bool IsActive { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Results.BlogImageResults
{
    public class GetBlogImageQueryResult : BaseResult
    {
        public int BlogId { get; set; }

        public string ImagePath { get; set; }
    }
}

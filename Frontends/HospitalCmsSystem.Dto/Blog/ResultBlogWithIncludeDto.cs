using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Dto.Blog
{
    public class ResultBlogWithIncludeDto
    {

        public Comment[] Comment { get; set; }
        public int BlogId { get; set; }
        public string[] Categories { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string[] Tags { get; set; }
        public Imagepath[] ImagePath { get; set; }
        public DateTime CreatedAt { get; set; }

    }

    public class Comment
    {
        public int BlogCommentId { get; set; }
        public string comment { get; set; }
        public bool IsActive { get; set; }
    }

    public class Imagepath
    {
        public int BlogImageId { get; set; }
        public string imagePath { get; set; }
    }
}

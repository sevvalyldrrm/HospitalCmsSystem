using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.BlogCommands
{
    public class UpdateBlogCommand : IRequest
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public List<string> Categories { get; set; } = new List<string>();
    }
}

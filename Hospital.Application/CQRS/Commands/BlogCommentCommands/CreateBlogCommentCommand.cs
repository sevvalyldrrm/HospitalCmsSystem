using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.BlogCommentCommands
{
	public class CreateBlogCommentCommand : IRequest
	{
        public int BlogId { get; set; }
        public string Comment { get; set; }
        public bool IsActive { get; set; }
        public int AppUserId { get; set; }
    }
}

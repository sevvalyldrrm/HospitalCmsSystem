using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.DepartmentBlogCommands
{
	public class CreateDepartmentBlogCommand : IRequest
	{
        public int DepartmentId { get; set; }

        public int BlogId { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.DepartmentBlogCommands
{
	public class RemoveDepartmentBlogCommand: IRequest
	{
		public int Id { get; set; }
		public RemoveDepartmentBlogCommand(int id)
		{
			Id = id;
		}

	}
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.BlogCommentCommands
{
	public class RemoveBlogCommentCommand: IRequest
	{
		public int Id { get; set; }
		public RemoveBlogCommentCommand(int id)
		{
			Id = id;
		}

	}
}

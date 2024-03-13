﻿using HospitalCmsSystem.Application.CQRS.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Commands.BlogImageCommands
{
	public class UpdateBlogImageCommand : IRequest
	{
		public int Id { get; set; }
        public int BlogId { get; set; }

        public string ImagePath { get; set; }
    }
}

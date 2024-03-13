﻿
using HospitalCmsSystem.Application.CQRS.Results.BlogCommentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Queries.BlogCommentQueries
{
	public class GetBlogCommentByIdQuery : IRequest<GetBlogCommentByIdQueryResult>
	{
		public int Id { get; set; }

        public GetBlogCommentByIdQuery(int id)
        {
            Id = id;
        }
    }
}

﻿using HospitalCmsSystem.Application.CQRS.Results.DepartmentBlogResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Queries.DepartmentBlogQueries
{
	public class GetDepartmentBlogQuery : IRequest<List<GetDepartmentBlogQueryResult>>
	{

	}
}

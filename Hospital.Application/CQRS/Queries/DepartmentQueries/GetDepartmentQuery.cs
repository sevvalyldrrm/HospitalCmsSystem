﻿using HospitalCmsSystem.Application.CQRS.Results.DepartmentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Queries.DepartmentQueries
{
	public class GetDepartmentQuery : IRequest<List<GetDepartmentQueryResult>>
	{

	}
}

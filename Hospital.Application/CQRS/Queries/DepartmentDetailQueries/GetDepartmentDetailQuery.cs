﻿using HospitalCmsSystem.Application.CQRS.Results.DepartmentDetailResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Queries.DepartmentDetailQueries
{
	public class GetDepartmentDetailQuery : IRequest<List<GetDepartmentDetailQueryResult>>
	{

	}
}

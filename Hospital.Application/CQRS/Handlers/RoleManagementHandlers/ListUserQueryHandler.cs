using HospitalCmsSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Handlers.RoleManagementHandlers
{
    public class ListUserQueryHandler : IRequestHandler<ListUserQuery, List<AppUser>>
    {
        private readonly UserManager<AppUser> _userManager;

        public ListUserQueryHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<AppUser>> Handle(ListUserQuery request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users.ToList();
            return users;
        }
    }
    public class ListUserQuery : IRequest<List<AppUser>>
    {
    }

}

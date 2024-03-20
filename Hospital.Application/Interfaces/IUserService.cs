using HospitalCmsSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.Interfaces
{
    public interface IUserService
    {
        Task<AppUser> Authenticate(string username, string password);
        Task<IEnumerable<AppUser>> GetAllUsers();
        Task<AppUser> GetUserById(Guid id);
        Task<AppUser> CreateUser(AppUser user, string password);
        Task UpdateUser(AppUser user, string password = null);
        Task DeleteUser(Guid id);
    }
}

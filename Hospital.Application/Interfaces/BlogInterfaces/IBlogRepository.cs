using HospitalCmsSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.Interfaces.BlogInterfaces
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetBlogWithInclude();
    }
}

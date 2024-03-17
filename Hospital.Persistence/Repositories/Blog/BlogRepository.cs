using HospitalCmsSystem.Application.Interfaces.BlogInterfaces;
using HospitalCmsSystem.Domain.Entities;
using HospitalCmsSystem.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Persistence.Repositories.Blog
{
    public class BlogRepository : IBlogRepository
    {
        private readonly AppDbContext _context;
        public BlogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Entities.Blog>> GetBlogWithInclude()
        {
           return await _context.Blogs.Include(x => x.BlogComments).Include(x=> x.BlogImages).ToListAsync();
        }
    }
}

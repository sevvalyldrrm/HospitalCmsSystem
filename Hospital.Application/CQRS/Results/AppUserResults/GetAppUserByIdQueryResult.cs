using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Results.AppUserResults
{
    public class GetAppUserByIdQueryResult : BaseResult
    {
        public string? FullName { get; set; }
        public string? City { get; set; }
        public bool IsActive { get; set; } = true;
        public string? ImagePath { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }
    }
}

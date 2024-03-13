using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCmsSystem.Application.CQRS.Results.ContactResults
{
    public class GetContactByIdQueryResult : BaseResult
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}

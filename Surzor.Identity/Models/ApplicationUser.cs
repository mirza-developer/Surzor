using Microsoft.AspNetCore.Identity;
using System;

namespace Surzor.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreateDateTime { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? LastModifyDateTime { get; set; }
        public Guid? LastModifiedBy { get; set; }
    }
}

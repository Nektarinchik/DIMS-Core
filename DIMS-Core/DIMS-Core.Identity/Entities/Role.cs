using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DIMS_Core.Identity.Entities
{
    public class Role : IdentityRole<int>
    {
        public virtual ICollection<IdentityUserRole<int>> UserRoles { get; set; }
    }
}
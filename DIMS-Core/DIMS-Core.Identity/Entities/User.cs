using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DIMS_Core.Identity.Entities
{
    public class User : IdentityUser<int>
    {
        public virtual ICollection<IdentityUserRole<int>> UserRoles { get; set; }
    }
}
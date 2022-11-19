using System.Collections.Generic;
using System.Linq;
using DIMS_Core.Identity.Entities;

namespace DIMS_Core.Identity.Helpers
{
    internal static class RoleHelper
    {
        public static IEnumerable<Role> GetRolesData()
        {
            return IdentityConstants.RoleNames.Roles.Select((roleName, i) => new Role
                                                                             {
                                                                                 Id = i + 1,
                                                                                 Name = roleName
                                                                             });
        }
    }
}
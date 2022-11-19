using System.Linq;
using DIMS_Core.Identity.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DIMS_Core.Identity.Configs
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<int>> builder)
        {
            builder.HasData(new IdentityUserRole<int>()
                            {
                                RoleId = RoleHelper.GetRolesData()
                                                   .Single(q => q.Name == IdentityConstants.RoleNames.Admin)
                                                   .Id,
                                UserId = 1
                            });
        }
    }
}
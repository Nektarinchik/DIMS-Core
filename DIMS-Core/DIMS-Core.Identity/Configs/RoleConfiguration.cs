using DIMS_Core.Identity.Entities;
using DIMS_Core.Identity.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DIMS_Core.Identity.Configs
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasMany(q => q.UserRoles)
                   .WithOne()
                   .HasForeignKey(q => q.RoleId);
            builder.HasData(RoleHelper.GetRolesData());
        }
    }
}
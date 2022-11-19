using System.Collections.Generic;
using System.Security.Cryptography;
using DIMS_Core.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DIMS_Core.Identity.Configs
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        private const string AdminEmail = "admin@test.com";
        private const string AdminPassword = "Qwerty1!";

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(q => q.UserRoles)
                   .WithOne()
                   .HasForeignKey(q => q.UserId);

            var hasher = new PasswordHasher<User>();
            foreach (var user in GetUsersData())
            {
                user.PasswordHash = hasher.HashPassword(user, AdminPassword);
                builder.HasData(user);
            }
        }

        private static IEnumerable<User> GetUsersData()
        {
            yield return new User
                         {
                             Id = 1,
                             Email = AdminEmail,
                             NormalizedEmail = AdminEmail.ToUpper(),
                             UserName = AdminEmail,
                             NormalizedUserName = AdminEmail.ToUpper(),
                             SecurityStamp = GetSecurityStamp()
                         };
        }

        private static string GetSecurityStamp()
        {
            var assembly = typeof(UserManager<>).Assembly;
            var type = assembly.GetType("Microsoft.AspNetCore.Identity.Base32");
            var methodInfo = type!.GetMethod("ToBase32");
            var bytes = new byte[20];
            RandomNumberGenerator.Fill(bytes);

            return methodInfo!.Invoke(null,
                                      new object[]
                                      {
                                          bytes
                                      }) as string;
        }
    }
}
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIMS_Core.Tests.Repositories.Fixtures
{
    internal class UserProfileRepositoryFixture : AbstractRepositoryFixture<UserProfile>
    {
        public UserProfileRepositoryFixture() :
            base(typeof(UserProfileRepository))
        {

        }
        protected override void InitDatabase()
        {
            var entity = Context.UserProfiles.Add(new UserProfile()
            {
                DirectionId = 1,
                FirstName = "Nikita",
                Email = "default@gmail.com",
                LastName = "Ermolaev",
                Sex = 1,
                Education = "BSUIR",
                BirthDate = new DateTime(2003, 3, 10),
                UniversityAverageScore = 8.5,
                MathScore = 8.0,
                Address = "address",
                MobilePhone = "phone",
                Skype = "skype",
                StartDate = new DateTime(2022, 8, 4)
            });
            EntityId = entity.Entity.UserId;

            Context.SaveChanges();
            entity.State = EntityState.Detached;
        }
    }
}

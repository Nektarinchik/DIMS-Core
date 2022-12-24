using DIMS_Core.DataAccessLayer.Interfaces;
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
    internal class UserTaskRepositoryFixture : AbstractRepositoryFixture<UserTask>
    {
        public UserTaskRepositoryFixture() :
            base(typeof(UserTaskRepository))
        {
        }

        protected override void InitDatabase()
        {
            var entry = Context.UserTasks.Add(new UserTask()
                {
                    UserId  = 1,
                    TaskId  = 1,
                    StateId = 1
                });
            EntityId = entry.Entity.UserTaskId;

            Context.SaveChanges();
            entry.State = EntityState.Detached;
        }
    }
}

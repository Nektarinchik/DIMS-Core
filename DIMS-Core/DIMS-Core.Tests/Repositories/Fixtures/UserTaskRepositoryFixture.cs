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
    internal class UserTaskRepositoryFixture : IDisposable
    {
        public DimsCoreContext Context { get; set; }
        public IUserTaskRepository Repository { get; set; }
        public int EntityId { get; set; }
        public int SuccessStateId { get; set; }
        public int FailStateId { get; set; }
        public int ActiveStateId { get; set; }
        public UserTaskRepositoryFixture()
        {
            Context = CreateContext();
            Repository = new UserTaskRepository(Context);

            InitDatabase();
        }

        private void InitDatabase()
        {
            var entry = Context.UserTasks.Add(new UserTask()
                {
                    UserId  = 1,
                    TaskId  = 1,
                    StateId = 1
                });
            EntityId = entry.Entity.UserTaskId;

            var activeEntry = Context.TaskStates.Add(new TaskState()
            {
                StateName = "Active"
            });
            ActiveStateId = activeEntry.Entity.StateId;

            var successEntry = Context.TaskStates.Add(new TaskState()
            {
                StateName = "Success"
            });
            SuccessStateId = successEntry.Entity.StateId;

            var failEntry = Context.TaskStates.Add(new TaskState()
            {
                StateName = "Fail"
            });
            FailStateId = failEntry.Entity.StateId;

            Context.SaveChanges();
            entry.State = EntityState.Detached;
            activeEntry.State = EntityState.Detached;
            successEntry.State = EntityState.Detached;
            failEntry.State = EntityState.Detached;
        }
        
        private static DimsCoreContext CreateContext()
        {
            return new DimsCoreContext(GetOptions());
        }
        private static DbContextOptions<DimsCoreContext> GetOptions()
        {
            var builder = new DbContextOptionsBuilder<DimsCoreContext>().UseInMemoryDatabase(GetInMemoryDbName());

            return builder.Options;
        }

        private static string GetInMemoryDbName()
        {
            return $"InMemory_{Guid.NewGuid()}";
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}

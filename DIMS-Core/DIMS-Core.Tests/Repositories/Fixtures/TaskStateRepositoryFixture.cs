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
    internal class TaskStateRepositoryFixture : IDisposable
    {
        public DimsCoreContext Context { get; set; }
        public IRepository<TaskState> Repository { get; set; }
        public int EntityId { get; set; }
        public TaskStateRepositoryFixture()
        {
            Context = CreateContext();
            Repository = new TaskStateRepository(Context);

            InitDatabase();
        }

        private void InitDatabase()
        {

            var entry = Context.TaskStates.Add(new TaskState()
            {
                StateName = "Active"
            });
            EntityId = entry.Entity.StateId;

            Context.SaveChanges();
            entry.State = EntityState.Detached;
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

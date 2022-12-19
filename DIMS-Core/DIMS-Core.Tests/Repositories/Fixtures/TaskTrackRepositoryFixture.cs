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
    internal class TaskTrackRepositoryFixture : IDisposable
    {
        public DimsCoreContext Context { get; set; }
        public IRepository<TaskTrack> Repository { get; set; }
        public int EntityId { get; set; }
        public TaskTrackRepositoryFixture()
        {
            Context = CreateContext();
            Repository = new TaskTrackRepository(Context);

            InitDatabase();
        }

        private void InitDatabase()
        {

            var entry = Context.TaskTracks.Add(new TaskTrack()
            {
                UserTaskId = 1,
                TrackDate = new DateTime(2003, 3, 10),
                TrackNote = "Test track note"
            });
            EntityId = entry.Entity.TaskTrackId;
            
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

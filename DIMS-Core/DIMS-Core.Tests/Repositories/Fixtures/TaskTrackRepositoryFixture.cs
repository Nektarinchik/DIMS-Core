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
    internal class TaskTrackRepositoryFixture : AbstractRepositoryFixture<TaskTrack>
    {
        public TaskTrackRepositoryFixture() :
            base(typeof(TaskTrackRepository))
        {
        }
        protected override void InitDatabase()
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
    }
}

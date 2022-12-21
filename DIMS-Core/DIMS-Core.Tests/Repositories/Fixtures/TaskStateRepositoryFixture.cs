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
    internal class TaskStateRepositoryFixture : AbstractRepositoryFixture<TaskState>
    {
        public TaskStateRepositoryFixture() :
            base(typeof(TaskStateRepository))
        {
        }

        protected override void InitDatabase()
        {

            var entry = Context.TaskStates.Add(new TaskState()
            {
                StateName = "Active"
            });
            EntityId = entry.Entity.StateId;

            Context.SaveChanges();
            entry.State = EntityState.Detached;
        }

    }
}

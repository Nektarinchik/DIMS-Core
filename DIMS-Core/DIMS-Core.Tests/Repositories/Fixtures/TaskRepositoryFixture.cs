using System;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.X509;
using Task = DIMS_Core.DataAccessLayer.Models.Task;
namespace DIMS_Core.Tests.Repositories.Fixtures;

internal class TaskRepositoryFixture : AbstractRepositoryFixture<Task>
{
    public int TaskId { get; set; }
    

    public TaskRepositoryFixture() : base(typeof(TaskRepository))
    {
    }

    protected override void InitDatabase()
    {
        var newTask = Context.Tasks.Add(new Task() 
            { 
               Name = "Task Name",
               Description = "Task Description", 
               StartDate = DateTime.Now.Date, 
               DeadlineDate = DateTime.Now.AddDays(1).Date
          });

        EntityId = newTask.Entity.TaskId;
        
        Context.SaveChangesAsync();
        newTask.State = EntityState.Detached;
    }
}
using System;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories;

namespace DIMS_Core.Tests.Repositories.Fixtures;

public class TaskRepositoryFixture : AbstractRepositoryFixture<TaskRepository>
{
    
    public int TaskId { get; set; }
    //public int DeleteTaskId { get; set; }
    //public int AddTaskId { get; set; }

    public override TaskRepository CreateRepository()
    {
        return new (Context);
    }

    protected override async void InitDB()
    {
        TaskId = (await Context.Tasks.AddAsync(new Task()
                                                     {
                                                         Name = "Task Name",
                                                         Description = "Task Description",
                                                         StartDate = DateTime.Now.Date,
                                                         DeadlineDate = DateTime.Now.AddDays(1).Date
                                                     })).Entity.TaskId;

        await Context.SaveChangesAsync();
    }
}
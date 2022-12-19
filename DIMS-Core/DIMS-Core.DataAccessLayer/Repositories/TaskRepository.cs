using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using ThreadTask = System.Threading.Tasks.Task;

namespace DIMS_Core.DataAccessLayer.Repositories;

public class TaskRepository : Repository<Task>
{
    public TaskRepository(DbContext context) : base(context)
    {
        
    }
    
    public override async ThreadTask Delete(int id)
    {
        await GetDatabaseFacade().ExecuteSqlRawAsync("Exec DeleteTask @TaskId", id);
    }
}
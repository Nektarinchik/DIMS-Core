using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.DataAccessLayer.Repositories;

public class TaskRepository : Repository<Task>
{
    public TaskRepository(DbContext context) : base(context)
    {
    }
}
using System.Threading.Tasks;
using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Interfaces;

namespace DIMS_Core.BusinessLayer.Services;

public class TaskService : Service<TaskModel, Task, IRepository<Task>>, ITaskService
{
    public TaskService(IMapper mapper, IRepository<Task> repository) : base(mapper, repository)
    {
    }
}
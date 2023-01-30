using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;

namespace DIMS_Core.BusinessLayer.Services;

public class TaskStateService : Service<TaskStateModel, TaskState, IRepository<TaskState>>, ITaskStateService
{
    public TaskStateService(IMapper mapper, IRepository<TaskState> repository) : base(mapper, repository)
    {
    }
}
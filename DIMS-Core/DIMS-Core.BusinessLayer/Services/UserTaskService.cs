using AutoMapper;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;

namespace DIMS_Core.BusinessLayer.Services;

public class UserTaskService : Service<UserTaskModel, UserTask, IRepository<UserTask>>
{
    public UserTaskService(IMapper mapper, IRepository<UserTask> repository) : base(mapper, repository)
    {
    }
}

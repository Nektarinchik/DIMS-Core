using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;

namespace DIMS_Core.BusinessLayer.Services;

public class VUserTaskService : ReadOnlyService<VUserTaskModel, VUserTask, IRepository<VUserTask>>
{
    public VUserTaskService(IMapper mapper, IRepository<VUserTask> repository) : base(mapper, repository)
    {
    }
}
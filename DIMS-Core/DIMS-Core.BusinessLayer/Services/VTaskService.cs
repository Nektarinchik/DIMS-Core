using AutoMapper;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;

namespace DIMS_Core.BusinessLayer.Services;

public class VTaskService : ReadOnlyService<VTaskModel, VTask, IRepository<VTask>>
{
    public VTaskService(IMapper mapper, IRepository<VTask> repository) : base(mapper, repository)
    {
    }
}
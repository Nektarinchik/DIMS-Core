using AutoMapper;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;

namespace DIMS_Core.BusinessLayer.Services;

public class VUserProgressService : ReadOnlyService<VUserProgressModel, VUserProgress, IRepository<VUserProgress>>
{
    public VUserProgressService(IMapper mapper, IRepository<VUserProgress> repository) : base(mapper, repository)
    {
    }
}
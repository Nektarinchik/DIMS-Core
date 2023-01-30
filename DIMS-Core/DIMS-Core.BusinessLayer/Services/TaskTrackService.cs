using System.Threading.Tasks;
using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;

namespace DIMS_Core.BusinessLayer.Services;

public class TaskTrackService : Service<TaskTrackModel, TaskTrack, IRepository<TaskTrack>>, ITaskTrackService
{
    public TaskTrackService(IMapper mapper, IRepository<TaskTrack> repository) : base(mapper, repository)
    {
    }
}
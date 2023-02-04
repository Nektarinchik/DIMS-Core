

using AutoMapper;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;

namespace DIMS_Core.BusinessLayer.Services;

public class VUserTrackService : ReadOnlyService<VUserTrackModel, VUserTrack, IRepository<VUserTrack>>
{
    public VUserTrackService(IMapper mapper, IRepository<VUserTrack> repository) : base(mapper, repository)
    {
    }
}
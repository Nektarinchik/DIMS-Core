using AutoMapper;
using DIMS_Core.BusinessLayer.Models;
using VUserTaskEntity = DIMS_Core.DataAccessLayer.Models.VUserTask;

namespace DIMS_Core.BusinessLayer.MappingProfiles
{
    public class VUserTaskProfile : Profile
    {
        public VUserTaskProfile()
        {
            CreateMap<VUserTaskEntity, VUserTaskModel>()
                .ReverseMap();
        }
    }
}

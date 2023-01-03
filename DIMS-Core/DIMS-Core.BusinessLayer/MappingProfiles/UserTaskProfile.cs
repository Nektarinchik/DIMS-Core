using AutoMapper;
using DIMS_Core.BusinessLayer.Models;

using UserTaskEntity = DIMS_Core.DataAccessLayer.Models.UserTask;

namespace DIMS_Core.BusinessLayer.MappingProfiles
{
    public class UserTaskProfile : Profile
    {
        public UserTaskProfile()
        {
            CreateMap<UserTaskEntity, UserTaskModel>()
                .ReverseMap();
        }
    }
}

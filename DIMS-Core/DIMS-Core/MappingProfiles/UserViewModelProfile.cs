using System.Linq;
using AutoMapper;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.Common.Extensions;
using DIMS_Core.Models;

namespace DIMS_Core.MappingProfiles
{
    public class UserViewModelProfile : Profile
    {
        public UserViewModelProfile()
        {
            CreateMap<UserProfileModel, UserProfileViewModel>()
                .ForMember(q => q.FullName,
                           q => q.MapFrom(w => new[]
                                               {
                                                   w.FirstName,
                                                   w.LastName
                                               }.Where(e => !e.IsNullOrWhiteSpace())
                                                .ToSeparatedString(" ")));
            CreateMap<UserProfileViewModel, UserProfileModel>();

            CreateMap<VUserProfileModel, VUserProfileViewModel>()
                .ReverseMap();
        }
    }
}
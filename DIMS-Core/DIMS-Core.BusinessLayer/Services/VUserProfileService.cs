using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.MappingProfiles;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.BusinessLayer.Services
{
    public class VUserProfileService : ReadOnlyService<VUserProfileModel, VUserProfile, IRepository<VUserProfile>>, IVUserProfileService
    {
        public VUserProfileService(IMapper mapper, IRepository<VUserProfile> repository) : base(mapper, repository)
        {
        }
    }
}
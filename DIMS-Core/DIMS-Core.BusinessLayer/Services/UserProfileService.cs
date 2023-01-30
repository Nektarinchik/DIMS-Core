using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.BusinessLayer.Services
{
    public class UserProfileService : Service<UserProfileModel, UserProfile, IRepository<UserProfile>>, IUserProfileService
    {
        public UserProfileService(IMapper mapper, IRepository<UserProfile> repository) : base(mapper, repository)
        {
        }

        /// <summary>
        ///     This method checks models equality by operator == overloading
        /// </summary>
        /// <param name="userModel1"></param>
        /// <param name="userModel2"></param>
        /// <returns></returns>
        public bool Equal(UserProfileModel userModel1, UserProfileModel userModel2)
        {
            return userModel1 == userModel2;
        }

        /// <summary>
        ///     This method checks models inequality by operator != overloading
        /// </summary>
        /// <param name="userModel1"></param>
        /// <param name="userModel2"></param>
        /// <returns></returns>
        public bool NotEqual(UserProfileModel userModel1, UserProfileModel userModel2)
        {
            return userModel1 != userModel2;
        }
    }
}
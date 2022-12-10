using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.BusinessLayer.Services
{
    public class UserProfileService : DataServiceBase, IUserProfileService
    {
        public UserProfileService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IReadOnlyCollection<UserProfileModel>> GetAll()
        {
            return await UnitOfWork.UserProfileRepository
                                   .GetAll()
                                   .ProjectTo<UserProfileModel>(Mapper.ConfigurationProvider)
                                   .ToArrayAsync();
        }

        public async Task<UserProfileModel> GetById(int id)
        {
            var userProfile = await UnitOfWork.UserProfileRepository.GetById(id);

            return Mapper.Map<UserProfileModel>(userProfile);
        }

        public async Task<UserProfileModel> Update(UserProfileModel userProfileModel)
        {
            var userProfile = await UnitOfWork.UserProfileRepository.GetById(userProfileModel.UserId);

            Mapper.Map(userProfileModel, userProfile);

            var updatedUserProfile = UnitOfWork.UserProfileRepository.Update(userProfile);
            await UnitOfWork.Save();

            return Mapper.Map<UserProfileModel>(updatedUserProfile);
        }

        public async Task<UserProfileModel> Create(UserProfileModel userProfileModel)
        {
            var userProfile = Mapper.Map<UserProfile>(userProfileModel);

            var createdUserProfile = await UnitOfWork.UserProfileRepository.Create(userProfile);
            await UnitOfWork.Save();

            return Mapper.Map<UserProfileModel>(createdUserProfile);
        }

        public async Task Delete(int id)
        {
            await UnitOfWork.UserProfileRepository.Delete(id);
            await UnitOfWork.Save();
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
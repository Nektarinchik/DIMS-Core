using System.Threading.Tasks;
using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models.Account;
using DIMS_Core.Identity.Entities;
using DIMS_Core.Identity.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DIMS_Core.BusinessLayer.Services
{
    internal class UserService : IdentityService, IUserService
    {
        public UserService(IIdentityUnitOfWork identityUnitOfWork, IMapper mapper) : base(identityUnitOfWork, mapper)
        {
        }

        public Task<SignInResult> SignInAsync(SignInModel model)
        {
            return UnitOfWork.SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
        }

        public Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            var mappedEntity = Mapper.Map<User>(model);

            return UnitOfWork.UserManager.CreateAsync(mappedEntity, model.Password);
        }

        public Task SignOutAsync()
        {
            return UnitOfWork.SignInManager.SignOutAsync();
        }
    }
}
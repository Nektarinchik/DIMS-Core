using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.Identity.Interfaces;

namespace DIMS_Core.BusinessLayer.Services
{
    public abstract class IdentityService
    {
        protected readonly IMapper Mapper;
        protected readonly IIdentityUnitOfWork UnitOfWork;

        protected IdentityService(IIdentityUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public void Dispose()
        {
            UnitOfWork?.Dispose();
        }
    }
}
using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Interfaces;

namespace DIMS_Core.BusinessLayer.Services
{
    public abstract class DataServiceBase : IService
    {
        protected readonly IMapper Mapper;
        protected readonly IUnitOfWork UnitOfWork;

        protected DataServiceBase(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}
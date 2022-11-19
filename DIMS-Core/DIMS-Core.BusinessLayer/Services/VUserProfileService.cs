using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.BusinessLayer.Services
{
    public class VUserProfileService : IVUserProfileService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public VUserProfileService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<VUserProfileModel>> GetAll()
        {
            return await _unitOfWork.VUserProfileRepository.GetAll()
                              .ProjectTo<VUserProfileModel>(_mapper.ConfigurationProvider)
                              .ToArrayAsync();
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
    }
}
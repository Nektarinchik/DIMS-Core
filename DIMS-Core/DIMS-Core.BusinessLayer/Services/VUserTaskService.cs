
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DIMS_Core.BusinessLayer.Services
{
    public class VUserTaskService : IVUserTaskService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public VUserTaskService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }

        public async Task<IReadOnlyCollection<VUserTaskModel>> GetAll()
        {
            return await _unitOfWork.VUserTaskRepository.GetAll()
                .ProjectTo<VUserTaskModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}

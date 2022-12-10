using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.BusinessLayer.Services
{
    public class DirectionService : DataServiceBase, IDirectionService
    {
        public DirectionService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IReadOnlyCollection<DirectionModel>> GetAll()
        {
            var directions = UnitOfWork.DirectionRepository.GetAll();

            return await Mapper.ProjectTo<DirectionModel>(directions)
                               .ToArrayAsync();
        }

        public async Task<DirectionModel> GetById(int id)
        {
            var direction = await UnitOfWork.DirectionRepository.GetById(id);

            return Mapper.Map<DirectionModel>(direction);
        }

        public async Task<DirectionModel> Update(DirectionModel directionModel)
        {
            var direction = await UnitOfWork.DirectionRepository.GetById(directionModel.DirectionId);

            Mapper.Map(directionModel, direction);

            var updatedDirection = UnitOfWork.DirectionRepository.Update(direction);
            await UnitOfWork.Save();

            return Mapper.Map<DirectionModel>(updatedDirection);
        }

        public async Task<DirectionModel> Create(DirectionModel directionModel)
        {
            var direction = Mapper.Map<Direction>(directionModel);

            var createdDirection = await UnitOfWork.DirectionRepository.Create(direction);
            await UnitOfWork.Save();

            return Mapper.Map<DirectionModel>(createdDirection);
        }

        public async Task Delete(int id)
        {
            await UnitOfWork.DirectionRepository.Delete(id);
            await UnitOfWork.Save();
        }

        /// <summary>
        ///     This method check models equality by operator == overloading
        /// </summary>
        /// <param name="directionModel1"></param>
        /// <param name="directionModel2"></param>
        /// <returns></returns>
        public bool Equal(DirectionModel directionModel1, DirectionModel directionModel2)
        {
            return directionModel1 == directionModel2;
        }

        /// <summary>
        ///     This method check models inequality by operator != overloading
        /// </summary>
        /// <param name="directionModel1"></param>
        /// <param name="directionModel2"></param>
        /// <returns></returns>
        public bool NotEqual(DirectionModel directionModel1, DirectionModel directionModel2)
        {
            return directionModel1 != directionModel2;
        }
    }
}
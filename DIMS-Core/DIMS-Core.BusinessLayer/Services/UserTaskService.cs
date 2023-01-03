using AutoMapper;
using AutoMapper.QueryableExtensions;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.BusinessLayer.Services
{
    public class UserTaskService : DataServiceBase, IUserTaskService
    {
        public UserTaskService(IUnitOfWork unitOfWork, IMapper mapper) : 
            base(unitOfWork, mapper)
        {
        }

        public async Task<UserTaskModel> Create(UserTaskModel userTaskModel)
        {
            var entity = Mapper.Map<UserTask>(userTaskModel);
            var createdEntity = UnitOfWork.UserTaskRepository.Create(entity);
            await UnitOfWork.SaveAsync();

            return Mapper.Map<UserTaskModel>(await createdEntity);
        }

        public async Task Delete(int id)
        {
            await UnitOfWork.UserTaskRepository.Delete(id);
            await UnitOfWork.SaveAsync();
        }

        public async Task<IReadOnlyCollection<UserTaskModel>> GetAll()
        {
            return await UnitOfWork.UserTaskRepository.GetAll()
                .ProjectTo<UserTaskModel>(Mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<UserTaskModel> GetById(int id)
        {
            var userTask = await UnitOfWork.UserTaskRepository.GetById(id);

            return Mapper.Map<UserTaskModel>(userTask);
        }

        public async Task<UserTaskModel> Update(UserTaskModel userTaskModel)
        {
            var entity = await UnitOfWork.UserTaskRepository.GetById(userTaskModel.UserTaskId);
            
            Mapper.Map(userTaskModel, entity);

            var updatedEntity = UnitOfWork.UserTaskRepository.Update(entity);
            await UnitOfWork.SaveAsync();

            return Mapper.Map<UserTaskModel>(updatedEntity);
        }
    }
}

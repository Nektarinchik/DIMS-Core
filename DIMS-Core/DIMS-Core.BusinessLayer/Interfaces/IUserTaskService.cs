using DIMS_Core.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIMS_Core.BusinessLayer.Interfaces
{
    public interface IUserTaskService
    {
        public Task<UserTaskModel> Create(UserTaskModel userTaskModel);
        public Task<UserTaskModel> GetById(int id);
        public Task<IReadOnlyCollection<UserTaskModel>> GetAll();
        public Task<UserTaskModel> Update(UserTaskModel userTaskModel);
        public Task Delete(int id);

    }
}

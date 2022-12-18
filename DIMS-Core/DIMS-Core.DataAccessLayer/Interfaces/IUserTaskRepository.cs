using DIMS_Core.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.DataAccessLayer.Interfaces
{
    public interface IUserTaskRepository : IRepository<UserTask>
    {
        public void SetUserTaskAsFail(int userId, int taskId);
        public void SetUserTaskAsSuccess(int userId, int taskId);
    }
}

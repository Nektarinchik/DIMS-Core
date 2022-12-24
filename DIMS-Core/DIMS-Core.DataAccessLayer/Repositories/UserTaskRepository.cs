using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    public class UserTaskRepository : Repository<UserTask>, IUserTaskRepository
    {
        public UserTaskRepository(DimsCoreContext context) : base(context)
        {
        }
        public async Task SetUserTaskAsFail(int userId, int taskId)
        {
            await GetDatabaseFacade().ExecuteSqlInterpolatedAsync(
                $@"EXEC SetUserTaskAsFail {userId}, {taskId}");
        }

        public async Task SetUserTaskAsSuccess(int userId, int taskId)
        {
            await GetDatabaseFacade().ExecuteSqlInterpolatedAsync(
                $@"EXEC SetUserTaskAsSuccess {userId}, {taskId}");
        }
    }
}

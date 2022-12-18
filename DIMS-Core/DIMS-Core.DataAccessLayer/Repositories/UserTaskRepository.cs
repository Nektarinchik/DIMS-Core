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
            _ = await Set.FromSqlInterpolated($"EXEC SetUserTaskAsFail {userId}, {taskId};").ToListAsync();
        }

        public async Task SetUserTaskAsSuccess(int userId, int taskId)
        {
            _ = await Set.FromSqlInterpolated($"EXEC SetUserTaskAsSuccess {userId}, {taskId};").ToListAsync();
        }
    }
}

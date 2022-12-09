using DIMS_Core.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    internal class UserTaskRepository : Repository<UserTask>
    {
        public UserTaskRepository(DimsCoreContext context) : base(context)
        {
        }
    }
}

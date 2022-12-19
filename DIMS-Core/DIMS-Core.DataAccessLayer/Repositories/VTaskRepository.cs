using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    internal class VTaskRepository : IReadOnlyRepository<VTask>
    {
        private readonly DimsCoreContext _context;
        public VTaskRepository(DimsCoreContext context)
        {
            _context = context;
        }
        public IQueryable<VTask> GetAll()
        {
            return _context.VTasks.AsNoTracking();
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
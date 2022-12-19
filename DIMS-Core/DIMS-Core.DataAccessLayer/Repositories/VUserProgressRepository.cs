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
    internal class VUserProgressRepository : IReadOnlyRepository<VUserProgress>
    {
        private readonly DimsCoreContext _context;
        public VUserProgressRepository(DimsCoreContext context)
        {
            _context = context;
        }
        public IQueryable<VUserProgress> GetAll()
        {
            return _context.VUserProgresses.AsNoTracking();
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
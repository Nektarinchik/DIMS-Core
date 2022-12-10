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
    internal class VUserTrackRepository : IReadOnlyRepository<VUserTrack>
    {
        private readonly DimsCoreContext _context;
        public VUserTrackRepository(DimsCoreContext context)
        {
            _context = context;
        }
        public IQueryable<VUserTrack> GetAll()
        {
            return _context.VUserTracks.AsNoTracking();
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
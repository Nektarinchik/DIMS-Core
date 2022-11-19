using System.Linq;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    public class VUserProfileRepository : IReadOnlyRepository<VUserProfile>
    {
        private readonly DimsCoreContext _context;

        public VUserProfileRepository(DimsCoreContext context)
        {
            _context = context;
        }

        public IQueryable<VUserProfile> GetAll()
        {
            return _context.VUserProfiles.AsNoTracking();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
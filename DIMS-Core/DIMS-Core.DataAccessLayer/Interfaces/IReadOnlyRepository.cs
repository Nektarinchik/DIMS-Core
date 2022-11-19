using System;
using System.Linq;

namespace DIMS_Core.DataAccessLayer.Interfaces
{
    public interface IReadOnlyRepository<out T> : IDisposable
        where T : class
    {
        IQueryable<T> GetAll();
    }
}
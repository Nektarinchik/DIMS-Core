using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DIMS_Core.BusinessLayer.Models;

namespace DIMS_Core.BusinessLayer.Interfaces
{
    public interface IReadOnlyService<T> : IDisposable
        where T : class
    {
        Task<IReadOnlyCollection<T>> GetAll();
    }
}
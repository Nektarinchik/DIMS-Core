using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DIMS_Core.BusinessLayer.Models;

namespace DIMS_Core.BusinessLayer.Interfaces
{
    public interface IReadOnlyService<TModel> : IDisposable
    {
        Task<IReadOnlyCollection<TModel>> GetAll();
        
    }
}
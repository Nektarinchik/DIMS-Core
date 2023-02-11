using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.BusinessLayer.Services;

public class ReadOnlyService<TModel, TEntity, TRepository> : IReadOnlyService<TModel>
where TModel : class
where TEntity : class
where TRepository : IRepository<TEntity>
{
    private bool _disposed = false;
    private TRepository _repository;
    private readonly IMapper _mapper;

    public ReadOnlyService(IMapper mapper, TRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<IReadOnlyCollection<TModel>> GetAll()
    {
        var entities = _repository.GetAll();
        
        return await _mapper.ProjectTo<TModel>(entities)
                           .ToListAsync();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _repository?.Dispose();
            }
            _disposed = true;
        }
    }
}
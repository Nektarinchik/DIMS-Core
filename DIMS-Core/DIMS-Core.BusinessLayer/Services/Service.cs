using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.BusinessLayer.Services;

public abstract class Service <TModel, TEntity, TRepository> : IService<TModel>
    where TModel : class
    where TEntity : class
    where TRepository : IRepository<TEntity>
{
    private readonly IMapper _mapper;
    private TRepository _repository;
    private bool _disposed = false;

    public Service(IMapper mapper, TRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
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

    public async Task<TModel> GetById(int id)
    {
        var entity = await _repository.GetById(id);

        return _mapper.Map<TModel>(entity);
    }

    public async Task<IEnumerable<TModel>> GetAll()
    {
        var entities = _repository.GetAll();
        
        return await _mapper.ProjectTo<TModel>(entities)
                            .ToListAsync();
    }

    public async Task<TModel> Update(TModel model)
    {
        var mappedEntity = _mapper.Map<TEntity>(model);
        var updatedEntity = _repository.Update(mappedEntity);
        await _repository.Save();

        return _mapper.Map<TModel>(updatedEntity);
    }

    public async Task Delete(int id)
    {
        await _repository.Delete(id);
        await _repository.Save();
    }

    public async Task<TModel> Create(TModel model)
    {
        var mappedEntity = _mapper.Map<TEntity>(model);
        
        var createdEntity = await _repository.Create(mappedEntity);
        await _repository.Save();
        
        return _mapper.Map<TModel>(createdEntity);
    }
}
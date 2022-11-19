using System;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS_Core.DataAccessLayer.Interfaces
{
    /// <summary>
    ///     This is common description of repository pattern.
    ///     Repository is main pattern you have to remember when are working with database because it helps you to generalize
    ///     work with DB.
    ///     Actually many programmers think DbContext approach from EF is already repository pattern.
    ///     This idea has sense but I think it looks like another interesting pattern unit of work because DbContext has many
    ///     different subjects under one context.
    ///     In this case repository is DbSet but I prefer to use one more wrapper for DbContext like Repository pattern.
    ///     Details about this pattern you can read in Internet.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(int id);

        Task<TEntity> Create(TEntity entity);

        TEntity Update(TEntity entity);

        Task Delete(int id);

        Task Save();
    }
}
using System;
using System.Linq;
using System.Threading.Tasks;
using DIMS_Core.DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using DIMS_Core.Common.Exceptions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    /// <summary>
    ///     TODO: Task #1
    ///     Implement all methods
    ///     Generic Repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly DbContext _context;
        protected readonly DbSet<TEntity> Set;

        protected Repository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Set = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return Set.AsNoTracking();
        }

        public async Task<TEntity> GetById(int id)
        {
            if (id <= 0)
            {
                throw ExceptionsFactory.InvArgException(
                    System.Reflection.MethodBase.GetCurrentMethod().Name,
                    @$"Id = {id} is invalid. Id cannot be less than 1");
            }

            // TODO: type must be ad                    justed to entity type accordingly
            TEntity objectFromDB = await Set.FindAsync(id);

            if (objectFromDB is null)
            {

                throw ExceptionsFactory.DbObjectIsNullException(
                    System.Reflection.MethodBase.GetCurrentMethod().Name,
                    @$"Object by id = {id} that you try to retrieve from 
                    {GetType().Name} repository is null"
                    );
            }

            // RECOMMEND: It's better to create a helper static class for errors instead of throwing them
            // Ask us if you stucked and it looks ridiculous for you

            return objectFromDB;
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            EntityEntry<TEntity> create = await Set.AddAsync(entity);
            return create.Entity;
        }

        public TEntity Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            EntityEntry<TEntity> update = Set.Update(entity);
            return update.Entity;
        }

        public virtual async Task Delete(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException();
            }
            TEntity entity = await Set.FindAsync(id);
            Set.Remove(entity);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }
        
        protected DatabaseFacade GetDatabaseFacade()
        {
            return _context.Database;
        }
        /// <summary>
        ///     In most cases this method is not important because our context will be disposed by IoC automatically.
        ///     But if you don't know where will use your service better to specify this method (example, class library).
        /// </summary>
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
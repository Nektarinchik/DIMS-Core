using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIMS_Core.Tests.Repositories.Fixtures
{
    internal abstract class AbstractRepositoryFixture<TEntity> : IDisposable
        where TEntity : class
    {
        public AbstractRepositoryFixture(Type repositoryType)
        {
            Context = CreateContext();
            Repository = (IRepository<TEntity>)Activator.CreateInstance(repositoryType, Context);

            InitDatabase();
        }

        public DimsCoreContext Context { get; }

        public IRepository<TEntity> Repository { get; }

        public int EntityId { get; protected set; }

        public void Dispose()
        {
            Context.Dispose();
        }

        protected abstract void InitDatabase();

        private static DimsCoreContext CreateContext()
        {
            var options = GetOptions();

            return new DimsCoreContext(options);
        }

        private static DbContextOptions<DimsCoreContext> GetOptions()
        {
            var builder = new DbContextOptionsBuilder<DimsCoreContext>().UseInMemoryDatabase(GetInMemoryDbName());

            return builder.Options;
        }

        private static string GetInMemoryDbName()
        {
            return $"InMemory_{Guid.NewGuid()}";
        }
    }
}

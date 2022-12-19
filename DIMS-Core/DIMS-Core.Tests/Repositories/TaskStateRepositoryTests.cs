using DIMS_Core.Common.Exceptions;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.Tests.Repositories.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.Tests.Repositories
{
    public class TaskStateRepositoryTests : IDisposable
    {
        private readonly TaskStateRepositoryFixture _fixture;
        public TaskStateRepositoryTests()
        {
            _fixture = new TaskStateRepositoryFixture();
        }

        [Fact]
        public void GetAll_OK()
        {
            // Act
            var result = _fixture.Repository.GetAll();
            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(1, result.Count());
        }

        [Fact]
        public async Task GetById_OK()
        {
            // Arrange & Act
            var entity = await _fixture.Repository.GetById(_fixture.EntityId);
            // Assert
            Assert.NotNull(entity);
            Assert.Equal(_fixture.EntityId, entity.StateId);
            Assert.Equal("Active", entity.StateName);
        }

        [Fact]
        public async Task GetById_EmptyId_Fail()
        {
            // Arrange
            const int id = 0;
            // Act & Assert
            await Assert.ThrowsAsync<InvArgException>(() => _fixture.Repository.GetById(id));
        }

        [Fact]

        public async Task GetById_NotExistUserTask_Fail()
        {
            // Arrange
            const int id = int.MaxValue;

            // Act & Assert
            await Assert.ThrowsAsync<DbObjectIsNullException>(() => _fixture.Repository.GetById(id));
        }

        [Fact]
        public async Task Create_OK()
        {
            // Arrange
            var entity = new TaskState()
            {
                StateName = "Success"
            };

            // Act
            var monitoredEntity = await _fixture.Repository.Create(entity);
            await _fixture.Context.SaveChangesAsync();

            // Assert
            Assert.NotNull(monitoredEntity);
            Assert.NotEqual(default, monitoredEntity.StateId);
            Assert.Equal(entity.StateName, monitoredEntity.StateName);
        }

        [Fact]
        public async Task Create_EmptyEntity_Fail()
        {
            // Arrange, Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _fixture.Repository.Create(null));
        }

        [Fact]
        public async Task Update_OK()
        {
            // Arrange
            var entity = new TaskState()
            {
                StateName = "Success",
                StateId = _fixture.EntityId
            };

            // Act
            var updatedEntity = _fixture.Repository.Update(entity);
            await _fixture.Context.SaveChangesAsync();

            // Assert
            Assert.NotNull(updatedEntity);
            Assert.Equal(entity.StateId, updatedEntity.StateId);
            Assert.Equal(entity.StateName, updatedEntity.StateName);
        }

        [Fact]
        public void Update_EmptyEntity_Fail()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => _fixture.Repository.Update(null));
        }

        [Fact]
        public async Task Delete_OK()
        {
            // Arrange
            await _fixture.Repository.Delete(_fixture.EntityId);
            await _fixture.Context.SaveChangesAsync();

            // Act
            var deletedEntity = await _fixture.Context.TaskStates.FindAsync(_fixture.EntityId);

            // Assert
            await Assert.ThrowsAsync<DbObjectIsNullException>(() => _fixture.Repository.GetById(_fixture.EntityId));
            Assert.Null(deletedEntity);
        }

        [Fact]

        public async Task Delete_EmptyId_Fail()
        {
            // Arrange
            const int id = 0;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _fixture.Repository.Delete(id));
        }
        public void Dispose()
        {
            _fixture.Dispose();
        }
    }
}

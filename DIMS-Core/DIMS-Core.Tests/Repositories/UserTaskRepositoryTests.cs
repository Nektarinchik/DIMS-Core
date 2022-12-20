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
    public class UserTaskRepositoryTests : IDisposable
    {
        private readonly UserTaskRepositoryFixture _fixture;
        public UserTaskRepositoryTests()
        {
            _fixture = new UserTaskRepositoryFixture();
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
            // Arrange

            // Act
            var entity = await _fixture.Repository.GetById(_fixture.EntityId);
            // Assert
            Assert.NotNull(entity);
            Assert.Equal(_fixture.EntityId, entity.UserTaskId);
            Assert.Equal(1, entity.StateId);
            Assert.Equal(1, entity.UserId);
            Assert.Equal(1, entity.TaskId);
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
            var entity = new UserTask()
            {
                UserId = 2,
                TaskId = 2,
                StateId = 2
            };

            // Act
            var monitoredEntity = await _fixture.Repository.Create(entity);
            await _fixture.Context.SaveChangesAsync();

            // Assert
            Assert.NotNull(monitoredEntity);
            Assert.NotEqual(default, monitoredEntity.UserTaskId);
            Assert.Equal(entity.UserId, monitoredEntity.UserId);
            Assert.Equal(entity.TaskId, monitoredEntity.TaskId);
            Assert.Equal(entity.StateId, monitoredEntity.StateId);
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
            var entity = new UserTask()
            {
                TaskId = 2,
                UserId = 2,
                StateId = 2,
                UserTaskId = _fixture.EntityId
            };

            // Act
            var updatedEntity = _fixture.Repository.Update(entity);
            await _fixture.Context.SaveChangesAsync();

            // Assert
            Assert.NotNull(updatedEntity);
            Assert.Equal(entity.UserTaskId, updatedEntity.UserTaskId);
            Assert.Equal(entity.TaskId, updatedEntity.TaskId);
            Assert.Equal(entity.UserId, updatedEntity.UserId);
            Assert.Equal(entity.StateId, updatedEntity.StateId);
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
            var deletedEntity = await _fixture.Context.UserTasks.FindAsync(_fixture.EntityId);
            
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

        [Fact]
        public async Task SetUserTaskAsSuccess_OK()
        {
            // Arrange
            var entity = await _fixture.Context.UserTasks.FindAsync(_fixture.EntityId);
            entity.StateId = _fixture.ActiveStateId;
            await _fixture.Context.SaveChangesAsync();

            // Act
            await _fixture.Repository.SetUserTaskAsSuccess(entity.UserId, entity.TaskId);
            await _fixture.Context.SaveChangesAsync();

            // Assert
            var updatedEntity = await _fixture.Context.UserTasks.FindAsync(_fixture.EntityId);
            Assert.NotNull(updatedEntity);
            Assert.Equal(_fixture.SuccessStateId, updatedEntity.StateId);
        }

        [Fact]
        public async Task SetUserTaskAsFail_OK()
        {
            // Arrange
            var entity = await _fixture.Context.UserTasks.FindAsync(_fixture.EntityId);
            entity.StateId = _fixture.ActiveStateId;
            await _fixture.Context.SaveChangesAsync();

            // Act
            await _fixture.Repository.SetUserTaskAsFail(entity.UserId, entity.TaskId);
            await _fixture.Context.SaveChangesAsync();

            // Assert
            var updatedEntity = await _fixture.Context.UserTasks.FindAsync(_fixture.EntityId);
            Assert.NotNull(updatedEntity);
            Assert.Equal(_fixture.FailStateId, updatedEntity.StateId);
        }

        public void Dispose()
        {
            _fixture.Dispose();
        }
    }
}

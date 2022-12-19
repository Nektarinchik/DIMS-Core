using System;
using System.Threading.Tasks;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.Tests.Repositories.Fixtures;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.Tests.Repositories
{
    public class DirectionRepositoryTests : IDisposable
    {
        private readonly DirectionRepositoryFixture _fixture;

        public DirectionRepositoryTests()
        {
            _fixture = new DirectionRepositoryFixture();
        }

        public void Dispose()
        {
            _fixture.Dispose();
        }

        [Fact]
        // Note: GetAll will work always in our case. It can be thrown into EF Core.
        // But it is implementation details of EF Core so we mustn't test these cases.
        public async Task GetAll_OK()
        {
            // Act
            var result = await _fixture.Repository
                                       .GetAll()
                                       .ToArrayAsync();

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(1, result.Length);
        }

        [Fact]
        public async Task GetById_OK()
        {
            // Act
            var result = await _fixture.Repository.GetById(_fixture.DirectionId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(_fixture.DirectionId, result.DirectionId);
            Assert.Equal("Test Direction", result.Name);
            Assert.Equal("Test Description", result.Description);
        }

        [Fact]
        public async Task GetById_EmptyId_Fail()
        {
            // Arrange
            const int id = 0;

            // Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _fixture.Repository.GetById(id));
        }

        [Fact]
        public async Task GetById_NotExistDirection_Fail()
        {
            // Arrange
            const int id = int.MaxValue;

            // Act, Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _fixture.Repository.GetById(id));
        }

        [Fact]
        public async Task Create_OK()
        {
            // Arrange
            var entity = new Direction
                         {
                             Name = "Create",
                             Description = "Description"
                         };

            // Act
            var result = await _fixture.Repository.Create(entity);
            await _fixture.Context.SaveChangesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(default, result.DirectionId);
            Assert.Equal(entity.Name, result.Name);
            Assert.Equal(entity.Description, result.Description);
        }

        [Fact]
        public async Task Create_EmptyEntity_Fail()
        {
            // Arrange Act, Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _fixture.Repository.Create(null));
        }

        [Fact]
        public async Task Update_OK()
        {
            // Arrange
            var entity = new Direction
                         {
                             DirectionId = _fixture.DirectionId,
                             Name = "Create",
                             Description = "Description"
                         };

            // Act
            var result = _fixture.Repository.Update(entity);
            await _fixture.Context.SaveChangesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(default, result.DirectionId);
            Assert.Equal(entity.Name, result.Name);
            Assert.Equal(entity.Description, result.Description);
        }

        [Fact]
        public void Update_EmptyEntity_Fail()
        {
            // Arrange Act, Assert
            Assert.Throws<ArgumentNullException>(() => _fixture.Repository.Update(null));
        }

        [Fact]
        public async Task Delete_OK()
        {
            // Act
            await _fixture.Repository.Delete(_fixture.DirectionId);
            await _fixture.Context.SaveChangesAsync();

            // Assert
            var deletedEntity = await _fixture.Context.Directions.FindAsync(_fixture.DirectionId);
            Assert.Null(deletedEntity);
        }

        [Fact]
        public async Task Delete_EmptyId_Fail()
        {
            // Arrange
            const int id = 0;

            // Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _fixture.Repository.Delete(id));
        }
    }
}
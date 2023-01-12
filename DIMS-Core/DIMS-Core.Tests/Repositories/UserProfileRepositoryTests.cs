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
    public class UserProfileRepositoryTests : IDisposable
    {
        private readonly AbstractRepositoryFixture<UserProfile> _fixture;
        public UserProfileRepositoryTests()
        {
            _fixture = new UserProfileRepositoryFixture();
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
            Assert.Equal(_fixture.EntityId, entity.UserId);
            Assert.Equal(1, entity.DirectionId);
            Assert.Equal("Nikita", entity.FirstName);
            Assert.Equal("default@gmail.com", entity.Email);
            Assert.Equal("Ermolaev", entity.LastName);
            Assert.Equal(1, entity.Sex);
            Assert.Equal("BSUIR", entity.Education);
            Assert.Equal(new DateTime(2003, 3,10), entity.BirthDate);
            Assert.Equal(8.5, entity.UniversityAverageScore);
            Assert.Equal(8.0, entity.MathScore);
            Assert.Equal("address", entity.Address);
            Assert.Equal("phone", entity.MobilePhone);
            Assert.Equal("skype", entity.Skype);
            Assert.Equal(new DateTime(2022, 8, 4), entity.StartDate);
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
        public async Task GetById_NotExistTaskTrack_Fail()
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
            var entity = new UserProfile()
            {
                DirectionId = 2,
                FirstName = "John",
                Email = "john@gmail.com",
                LastName = "Doe",
                Sex = 0,
                Education = "MIT",
                BirthDate = new DateTime(1970, 1, 1),
                UniversityAverageScore = 10.0,
                MathScore = 10.0,
                Address = "addressTest",
                MobilePhone = "phoneTest",
                Skype = "skypeTest",
                StartDate = new DateTime(2022, 7, 5)
            };

            // Act
            var monitoredEntity = await _fixture.Repository.Create(entity);
            await _fixture.Context.SaveChangesAsync();

            // Assert
            Assert.NotNull(monitoredEntity);
            Assert.NotEqual(default, monitoredEntity.UserId);
            Assert.Equal(entity.DirectionId, monitoredEntity.DirectionId);
            Assert.Equal(entity.FirstName, monitoredEntity.FirstName);
            Assert.Equal(entity.Email, monitoredEntity.Email);
            Assert.Equal(entity.LastName, monitoredEntity.LastName);
            Assert.Equal(entity.Sex, monitoredEntity.Sex);
            Assert.Equal(entity.Education, monitoredEntity.Education);
            Assert.Equal(entity.BirthDate, monitoredEntity.BirthDate);
            Assert.Equal(entity.UniversityAverageScore, monitoredEntity.UniversityAverageScore);
            Assert.Equal(entity.MathScore, monitoredEntity.MathScore);
            Assert.Equal(entity.Address, monitoredEntity.Address);
            Assert.Equal(entity.MobilePhone, monitoredEntity.MobilePhone);
            Assert.Equal(entity.Skype, monitoredEntity.Skype);
            Assert.Equal(entity.StartDate, monitoredEntity.StartDate);
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
            var entity = new UserProfile()
            {
                UserId = _fixture.EntityId,
                DirectionId = 2,
                FirstName = "John",
                Email = "john@gmail.com",
                LastName = "Doe",
                Sex = 0,
                Education = "MIT",
                BirthDate = new DateTime(1970, 1, 1),
                UniversityAverageScore = 10.0,
                MathScore = 10.0,
                Address = "addressTest",
                MobilePhone = "phoneTest",
                Skype = "skypeTest",
                StartDate = new DateTime(2022, 7, 5)
            };

            // Act
            var updatedEntity = _fixture.Repository.Update(entity);
            await _fixture.Context.SaveChangesAsync();

            // Assert
            Assert.NotNull(updatedEntity);
            Assert.Equal(entity.UserId, updatedEntity.UserId);
            Assert.Equal(entity.DirectionId, updatedEntity.DirectionId);
            Assert.Equal(entity.FirstName, updatedEntity.FirstName);
            Assert.Equal(entity.Email, updatedEntity.Email);
            Assert.Equal(entity.LastName, updatedEntity.LastName);
            Assert.Equal(entity.Sex, updatedEntity.Sex);
            Assert.Equal(entity.Education, updatedEntity.Education);
            Assert.Equal(entity.BirthDate, updatedEntity.BirthDate);
            Assert.Equal(entity.UniversityAverageScore, updatedEntity.UniversityAverageScore);
            Assert.Equal(entity.MathScore, updatedEntity.MathScore);
            Assert.Equal(entity.Address, updatedEntity.Address);
            Assert.Equal(entity.MobilePhone, updatedEntity.MobilePhone);
            Assert.Equal(entity.Skype, updatedEntity.Skype);
            Assert.Equal(entity.StartDate, updatedEntity.StartDate);
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
            var deletedEntity = await _fixture.Context.UserProfiles.FindAsync(_fixture.EntityId);

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

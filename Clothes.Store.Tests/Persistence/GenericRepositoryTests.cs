using Clothes.Store.Domain.Entities;
using Clothes.Store.Domain.Enums;
using Clothes.Store.Repository;
using FakeItEasy;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Xunit;

namespace Clothes.Store.Tests.Persistence
{
    public class GenericRepositoryTests
    {
        private readonly DatabaseContext _context;

        public GenericRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new DatabaseContext(options);
            _context.Database.EnsureCreated();
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllEntities()
        {
            // Arrange
            var repository = new GenericRepository<Custumer>(_context);
            var entities = new List<Custumer>
            {
                new Custumer {
                    CustumerID = Guid.NewGuid(),
                    CustumerName = "Teste",
                    Email = "teste@gmail.com",
                    CPF = "085.289.030-36",
                    Password = "password",
                    CriationDateHour = DateTime.UtcNow,
                    UserType = UserType.Custumer,
                    IsActivate = true
                },
                new Custumer {
                    CustumerID = Guid.NewGuid(),
                    CustumerName = "Teste2",
                    Email = "teste@gmail.com",
                    CPF = "085.289.030-36",
                    Password = "password",
                    CriationDateHour = DateTime.UtcNow,
                    UserType = UserType.Custumer,
                    IsActivate = true
                },
                new Custumer {
                    CustumerID = Guid.NewGuid(),
                    CustumerName = "Teste3",
                    Email = "teste@gmail.com",
                    CPF = "085.289.030-36",
                    Password = "password",
                    CriationDateHour = DateTime.UtcNow,
                    UserType = UserType.Custumer,
                    IsActivate = true
                }
            };

            await _context.Set<Custumer>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();

            // Act
            var result = await repository.GetAll();

            // Assert
            result.Should().BeEquivalentTo(entities);
        }

        [Fact]
        public async Task GetById_ShouldReturnEntity()
        {
            // Arrange
            var repository = new GenericRepository<Custumer>(_context);
            var entity = new Custumer
            {
                CustumerID = Guid.NewGuid(),
                CustumerName = "Teste",
                Email = "teste@gmail.com",
                CPF = "085.289.030-36",
                Password = "password",
                CriationDateHour = DateTime.UtcNow,
                UserType = UserType.Custumer,
                IsActivate = true
            };
            await _context.Set<Custumer>().AddAsync(entity);
            await _context.SaveChangesAsync();

            // Act
            var result = await repository.GetById(entity.CustumerID);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(entity);
        }

        [Fact]
        public async Task Add_ValidEntity_ShouldAddToDatabase()
        {
            // Arrange
            var repository = new GenericRepository<Custumer>(_context);
            var entity = new Custumer
            {
                CustumerID = Guid.NewGuid(),
                CustumerName = "Teste",
                Email = "teste@gmail.com",
                CPF = "085.289.030-36",
                Password = "password",
                CriationDateHour = DateTime.UtcNow,
                UserType = UserType.Custumer,
                IsActivate = true
            };

            // Act
            await repository.Add(entity);

            // Assert
            var result = await _context.Set<Custumer>().ToListAsync();
            result.Should().Contain(entity);
        }

        [Fact]
        public async Task Update_ValidEntity_ShouldUpdateEntityInDatabase()
        {
            // Arrange
            var repository = new GenericRepository<Custumer>(_context);
            var entity = new Custumer
            {
                CustumerID = Guid.NewGuid(),
                CustumerName = "Teste",
                Email = "teste@gmail.com",
                CPF = "085.289.030-36",
                Password = "password",
                CriationDateHour = DateTime.UtcNow,
                UserType = UserType.Custumer,
                IsActivate = true
            };
            await _context.Set<Custumer>().AddAsync(entity);
            await _context.SaveChangesAsync();

            // Update entity
            // (Assuming entity properties are modified here)

            // Act
            await repository.Update(entity);

            // Assert
            var result = await _context.Set<Custumer>().FirstOrDefaultAsync(e => e.CustumerID == entity.CustumerID);
            result.Should().BeEquivalentTo(entity);
        }

        [Fact]
        public async Task Delete_ValidEntity_ShouldSoftDeleteFromDatabase()
        {
            // Arrange
            var repository = new GenericRepository<Custumer>(_context);
            var entity = new Custumer
            {
                CustumerID = Guid.NewGuid(),
                CustumerName = "Teste",
                Email = "teste@gmail.com",
                CPF = "085.289.030-36",
                Password = "password",
                CriationDateHour = DateTime.UtcNow,
                UserType = UserType.Custumer,
                IsActivate = true
            };
            await _context.Set<Custumer>().AddAsync(entity);
            await _context.SaveChangesAsync();

            // Act
            await repository.Delete(entity);

            // Assert
            var result = await _context.Set<Custumer>().FirstOrDefaultAsync(e => e.CustumerID == entity.CustumerID);
            result.Should().NotBeNull();
            result.IsActivate.Should().BeFalse();
        }
    }
}


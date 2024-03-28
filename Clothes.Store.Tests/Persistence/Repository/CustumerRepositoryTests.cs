using AutoMapper;
using Clothes.Store.Application.Models.InputModel;
using Clothes.Store.Application.Models.ViewModel;
using Clothes.Store.Domain.Entities;
using Clothes.Store.Repository.Repository;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using FakeItEasy;
using System;
using System.Threading.Tasks;
using Xunit;
using Clothes.Store.Application.Interfaces;
using Clothes.Store.Repository;
using Clothes.Store.Domain.Enums;

namespace Clothes.Store.Tests.Repository
{
    public class CustumerRepositoryTests
    {
        private readonly DatabaseContext _context;
        private readonly ICustumer _custumer;
        private readonly ILogger<CustumerRepository> _logger;

        public CustumerRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new DatabaseContext(options);
            _context.Database.EnsureCreated();

            _custumer = A.Fake<ICustumer>();
            _logger = A.Fake<ILogger<CustumerRepository>>();
        }

        [Fact]
        public async Task GetCustumerByEmail_ShouldReturnCustumer()
        {
            // Arrange
            var repository = new CustumerRepository(_context);
            var email = "test@example.com";
            var custumer = new Custumer
            {
                CustumerID = Guid.NewGuid(),
                CustumerName = "Teste",
                Email = email,
                CPF = "085.289.030-36",
                Password = "password",
                CriationDateHour = DateTime.UtcNow,
                UserType = UserType.Custumer,
                IsActivate = true
            };
            await _context.Set<Custumer>().AddAsync(custumer);
            await _context.SaveChangesAsync();

            // Act
            var result = repository.GetCustumerByEmail(email);

            // Assert
            result.Should().NotBeNull();
            result.Email.Should().Be(email);
        }

        [Fact]
        public async Task GetCustumerByEmailAsync_ShouldReturnCustumer()
        {
            // Arrange
            var repository = new CustumerRepository(_context);
            var email = "test@example.com";
            var custumer = new Custumer
            {
                CustumerID = Guid.NewGuid(),
                CustumerName = "Teste",
                Email = email,
                CPF = "085.289.030-36",
                Password = "password",
                CriationDateHour = DateTime.UtcNow,
                UserType = UserType.Custumer,
                IsActivate = true
            };
            await _context.Set<Custumer>().AddAsync(custumer);
            await _context.SaveChangesAsync();

            // Act
            var result = await repository.GetCustumerByEmailAsync(email);

            // Assert
            result.Should().NotBeNull();
            result.Email.Should().Be(email);
        }

        [Fact]
        public async Task GetCustumerByCPF_ShouldReturnCustumer()
        {
            // Arrange
            var repository = new CustumerRepository(_context);
            var cpf = "123.456.789-00";
            var custumer = new Custumer
            {
                CustumerID = Guid.NewGuid(),
                CustumerName = "Teste",
                Email = "test@example.com",
                CPF = cpf,
                Password = "password",
                CriationDateHour = DateTime.UtcNow,
                UserType = UserType.Custumer,
                IsActivate = true
            };
            await _context.Set<Custumer>().AddAsync(custumer);
            await _context.SaveChangesAsync();

            // Act
            var result = repository.GetCustumerByCPF(cpf);

            // Assert
            result.Should().NotBeNull();
            result.CPF.Should().Be(cpf);
        }
    }
}

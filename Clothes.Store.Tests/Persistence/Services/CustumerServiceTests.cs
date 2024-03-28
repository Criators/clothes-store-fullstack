using Clothes.Store.Application.Interfaces;
using Clothes.Store.Domain.Entities;
using Clothes.Store.Domain.Enums;
using Clothes.Store.Repository.Services;
using FakeItEasy;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Store.Tests.Persistence.Services
{
    public class CustumerServiceTests
    {
        [Fact]
        public async Task SaveCustumer_ShouldEncryptPasswordAndAddCustumer()
        {
            // Arrange
            var fakeCustumerRepository = A.Fake<ICustumer>();
            var custumerService = new CustumerService(fakeCustumerRepository);

            var custumer = new Custumer
            {
                CustumerID = Guid.NewGuid(),
                CustumerName = "Teste",
                Email = "test@example.com",
                CPF = "085.289.030-36",
                Password = "password",
                CriationDateHour = DateTime.UtcNow,
                UserType = UserType.Custumer,
                IsActivate = true
            };

            // Act
            var result = await custumerService.SaveCustumer(custumer);

            // Assert
            result.Should().NotBeNull();
            result.Password.Should().NotBeNullOrEmpty();
            A.CallTo(() => fakeCustumerRepository.Add(custumer)).MustHaveHappenedOnceExactly();
        }
    }
}

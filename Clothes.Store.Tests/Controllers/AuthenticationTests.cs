using Clothes.Store.Application.Interfaces.Services;
using Clothes.Store.Application.Models.InputModel;
using Clothes.Store.Server.Controllers;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Store.Tests.Controllers
{
    public class AuthenticationTests
    {
        [Fact]
        public async Task Login_ShouldReturnToken()
        {
            // Arrange
            var fakeTokenService = A.Fake<ITokenService>();
            var controller = new AuthenticationController(fakeTokenService);
            var inputModel = new AuthenticationInputModel
            {
                Email = "test@example.com",
                Password = "password"
            };

            var expectedToken = "generated_token";

            A.CallTo(() => fakeTokenService.GenerateToken(inputModel))
                .Returns(expectedToken);

            // Act
            var result = await controller.Login(inputModel) as OkObjectResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
            result.Value.Should().Be(expectedToken);
        }
    }
}

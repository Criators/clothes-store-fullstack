using AutoMapper;
using Clothes.Store.Application.Interfaces;
using Clothes.Store.Application.Interfaces.Services;
using Clothes.Store.Application.Models.ViewModel;
using Clothes.Store.Domain.Entities;
using Clothes.Store.Repository;
using Clothes.Store.Server.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FakeItEasy;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clothes.Store.Application.Models.InputModel;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Clothes.Store.Tests.Controllers
{
    public class CustumerTests
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly ICustumerService _custumerService;
        private readonly ICustumer _custumer;
        private readonly ILogger<CustumerController> _logger;

        public CustumerTests()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new DatabaseContext(options);
            _context.Database.EnsureCreated();

            _mapper = A.Fake<IMapper>();
            _custumerService = A.Fake<ICustumerService>();
            _custumer = A.Fake<ICustumer>();
            _logger = A.Fake<ILogger<CustumerController>>();
        }

        [Fact]
        public async Task GetById_ExistingId_ShouldReturnOkResultAsync()
        {
            // Arrange
            var controller = new CustumerController(_context, _mapper, _custumerService, _custumer, _logger);
            var custumerId = Guid.NewGuid();
            var custumer = new Custumer { CustumerID = custumerId };

            A.CallTo(() => _custumer.GetById(custumerId)).Returns(custumer);
            A.CallTo(() => _mapper.Map<CustumerViewModel>(custumer)).Returns(new CustumerViewModel { CustumerID = custumerId });

            // Act
            var result = await controller.GetById(custumerId) as OkObjectResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task GetById_NonExistingId_ShouldReturnNotFoundResultAsync()
        {
            // Arrange
            var controller = new CustumerController(_context, _mapper, _custumerService, _custumer, _logger);
            var custumerId = Guid.NewGuid();
            var custumer = (Custumer)null;

            A.CallTo(() => _custumer.GetById(custumerId)).Returns(Task.FromResult<Custumer>(null));

            // Act
            var result = await controller.GetById(custumerId) as NotFoundResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task Post_ValidInput_ShouldReturnCreatedAtAction()
        {
            // Arrange
            var controller = new CustumerController(_context, _mapper, _custumerService, _custumer, _logger);
            var inputModel = new CustumerInputModel();
            var custumer = new Custumer();
            var viewModel = new CustumerViewModel { CustumerID = Guid.NewGuid() };

            A.CallTo(() => _mapper.Map<Custumer>(inputModel)).Returns(custumer);
            A.CallTo(() => _custumerService.SaveCustumer(custumer)).Returns(custumer);
            A.CallTo(() => _mapper.Map<CustumerViewModel>(custumer)).Returns(viewModel);

            // Act
            var result = await controller.Post(inputModel) as CreatedAtActionResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(StatusCodes.Status201Created);
            result.ActionName.Should().Be(nameof(controller.GetById));
            result.RouteValues["id"].Should().Be(viewModel.CustumerID);
        }

        [Fact]
        public async Task Update_ExistingIdAndValidInput_ShouldReturnNoContent()
        {
            // Arrange
            var controller = new CustumerController(_context, _mapper, _custumerService, _custumer, _logger);
            var custumerId = Guid.NewGuid();
            var inputModel = new UpdateCustumerInputModel();
            var custumer = new Custumer { CustumerID = custumerId };

            A.CallTo(() => _custumer.GetById(custumerId)).Returns(custumer);

            // Act
            var result = await controller.Update(custumerId, inputModel) as NoContentResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(StatusCodes.Status204NoContent);
        }

        [Fact]
        public async Task Update_NonExistingId_ShouldReturnNotFoundResult()
        {
            // Arrange
            var controller = new CustumerController(_context, _mapper, _custumerService, _custumer, _logger);
            var custumerId = Guid.NewGuid();
            var custumer = (Custumer)null;

            A.CallTo(() => _custumer.GetById(custumerId)).Returns(custumer);

            // Act
            var result = await controller.Update(custumerId, new UpdateCustumerInputModel()) as NotFoundResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }


        [Fact]
        public async Task Delete_ExistingId_ShouldReturnNoContent()
        {
            // Arrange
            var controller = new CustumerController(_context, _mapper, _custumerService, _custumer, _logger);
            var custumerId = Guid.NewGuid();
            var custumer = new Custumer { CustumerID = custumerId };

            A.CallTo(() => _custumer.GetById(custumerId)).Returns(custumer);

            // Act
            var result = await controller.Delete(custumerId) as NoContentResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(StatusCodes.Status204NoContent);
        }

        [Fact]
        public async Task Delete_NonExistingId_ShouldReturnNotFoundResult()
        {
            // Arrange
            var controller = new CustumerController(_context, _mapper, _custumerService, _custumer, _logger);
            var custumerId = Guid.NewGuid();
            var custumer = (Custumer)null;

            A.CallTo(() => _custumer.GetById(custumerId)).Returns(custumer);

            // Act
            var result = await controller.Delete(custumerId) as NotFoundResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }
    }
}

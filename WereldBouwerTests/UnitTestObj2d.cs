using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using WereldbouwerAPI;
using WereldbouwerAPI.Controllers;
using Xunit;

namespace WereldBouwerTests
{
    public class UnitTestObj2d
    {
        private readonly Mock<IObject2DRepository> _mockRepo;
        private readonly Mock<IAuthenticationService> _mockAuthService;
        private readonly Mock<ILogger<Object2DController>> _mockLogger;
        private readonly Object2DController _controller;

        public UnitTestObj2d()
        {
            _mockRepo = new Mock<IObject2DRepository>();
            _mockAuthService = new Mock<IAuthenticationService>();
            _mockLogger = new Mock<ILogger<Object2DController>>();
            _controller = new Object2DController(_mockRepo.Object, _mockAuthService.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task GetByEnvironmentId_ReturnsObjects()
        {
            // Arrange
            var environmentId = "test-environment";
            var objects = new List<Object2D>
            {
                new Object2D { id = "1", environmentId = environmentId, prefabId = "prefab1" },
                new Object2D { id = "2", environmentId = environmentId, prefabId = "prefab2" }
            };
            _mockRepo.Setup(repo => repo.GetByEnvironmentIdAsync(environmentId)).ReturnsAsync(objects);

            // Act
            var result = await _controller.GetByEnvironmentId(environmentId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<Object2D>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public async Task AddObject2D_ReturnsCreatedObject()
        {
            // Arrange
            var newObject = new Object2D { prefabId = "prefab1", environmentId = "env1" };
            var createdObject = new Object2D { id = Guid.NewGuid().ToString(), prefabId = "prefab1", environmentId = "env1" };
            _mockRepo.Setup(repo => repo.AddObject2DAsync(It.IsAny<Object2D>())).ReturnsAsync(createdObject);

            // Act
            var result = await _controller.AddObject2D(newObject);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<Object2D>(okResult.Value);
            Assert.Equal(createdObject.id, returnValue.id);
        }

        [Fact]
        public async Task DeleteAllByEnvironmentId_ReturnsNoContent()
        {
            // Arrange
            var environmentId = "test-environment";
            _mockRepo.Setup(repo => repo.DeleteAllByEnvironmentIdAsync(environmentId)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.DeleteAllByEnvironmentId(environmentId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
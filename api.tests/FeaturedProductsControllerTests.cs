using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Xunit;
using Moq;
using api.Controllers;

namespace api.tests
{
    public class FeaturedProductsControllerTests
    {
        Mock<ILogger<FeaturedProductsController>> mockLogger = new Mock<ILogger<FeaturedProductsController>>();

        [Fact]
        public void Get_WhenCalled_ItReturnsAListOfFeaturedProducts()
        {
        //Arrange
        var controller = new FeaturedProductsController(mockLogger.Object);
        
        //Act
        var result = controller.Get();
        
        //Assert
        Assert.NotEmpty(result);
        }
    }
}
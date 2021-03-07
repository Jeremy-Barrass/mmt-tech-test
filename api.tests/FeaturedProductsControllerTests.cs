using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Xunit;
using Moq;
using api.Controllers;
using api.DbConnection;
using api.Interfaces;
using api.Models;

namespace api.tests
{
    public class FeaturedProductsControllerTests
    {
        Mock<ILogger<FeaturedProductsController>> mockLogger = new Mock<ILogger<FeaturedProductsController>>();
        Mock<IAppDbContext> mockDb = new Mock<IAppDbContext>();
        Mock<DbSet<Product>> mockSet = new Mock<DbSet<Product>>();
        List<Product> fakeData = new List<Product>{
            new Product
            {
                Name = "TestProd1",
                Sku = 10000
            },
            new Product
            {
                Name = "TestProd2",
                Sku = 20000
            },
            new Product
            {
                Name = "TestProd3",
                Sku = 30000
            },
            new Product
            {
                Name = "TestProd4",
                Sku = 40000
            },
            new Product
            {
                Name = "TestProd5",
                Sku = 50000
            },
        };

        private DbSet<T> MockDbSetSetup<T>(Mock<DbSet<T>> set, List<T> list) where T : class
        {
            var queryable = list.AsQueryable();
            set.As<IQueryable<T>>().Setup(dbs => dbs.Provider).Returns(queryable.Provider);
            set.As<IQueryable<T>>().Setup(dbs => dbs.Expression).Returns(queryable.Expression);
            set.As<IQueryable<T>>().Setup(dbs => dbs.ElementType).Returns(queryable.ElementType);
            set.As<IQueryable<T>>().Setup(dbs => dbs.GetEnumerator()).Returns(() => queryable.GetEnumerator());            
            return set.Object;
        }

        [Fact]
        public void Get_WhenCalled_ItReturnsAListOfFeaturedProducts()
        {
            //Arrange
            var mockSetObject = MockDbSetSetup(mockSet, fakeData);
            mockDb.Setup(db => db.Products).Returns(mockSetObject);

            var controller = new FeaturedProductsController(mockDb.Object, mockLogger.Object);
            
            //Act
            var result = controller.Get();
            
            //Assert
            Assert.NotEmpty(result);
        }
    }
}
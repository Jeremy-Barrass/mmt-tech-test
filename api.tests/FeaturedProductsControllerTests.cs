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
        Mock<DbSet<Product>> mockProductSet = new Mock<DbSet<Product>>();
        Mock<DbSet<string>> mockCategorySet = new Mock<DbSet<string>>();
        List<Product> fakeProductData = new List<Product>{
            new Product
            {
                Name = "TestProd1",
                Sku = 10000,
                Category = "TestCat1"
            },
            new Product
            {
                Name = "TestProd2",
                Sku = 20000,
                Category = "TestCat2"
            },
            new Product
            {
                Name = "TestProd3",
                Sku = 30000,
                Category = "TestCat3"
            },
            new Product
            {
                Name = "TestProd4",
                Sku = 40000,
                Category = "TestCat4"
            },
            new Product
            {
                Name = "TestProd5",
                Sku = 50000,
                Category = "TestCat5"
            },
        };
        List<string> fakeCategoryData = new List<string>{
            "TestCat1",
            "TestCat2",
            "TestCat3",
            "TestCat4",
            "TestCat5"
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
            var mockSetObject = MockDbSetSetup(mockProductSet, fakeProductData);
            mockDb.Setup(db => db.Products).Returns(mockSetObject);

            var controller = new FeaturedProductsController(mockDb.Object, mockLogger.Object);
            
            //Act
            var result = controller.Get();
            
            //Assert
            Assert.NotEmpty(result);
            // Featured products have SKU < 40000
            Assert.Empty(result.ToList().FindAll(p => p.Sku > 30000));
        }

        [Fact]
        public void Categories_WhenCalled_ItReturnsAListOfCategories()
        {
            //Arrange
            var mockSetObject = MockDbSetSetup(mockCategorySet, fakeCategoryData);
            mockDb.Setup(db => db.Categories).Returns(mockSetObject);

            var controller = new FeaturedProductsController(mockDb.Object, mockLogger.Object);

            //Act
            var result = controller.Categories();
            
            //Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetWithCategoryParam_WhenCalled_ItReturnsTheProductsWithThatCategory()
        {
            //Arrange
            var mockProductSetObject = MockDbSetSetup(mockProductSet, fakeProductData);
            mockDb.Setup(db => db.Products).Returns(mockProductSetObject);

            var controller = new FeaturedProductsController(mockDb.Object, mockLogger.Object);
                        
            //Act
            var result = controller.Get("TestCat3");
            
            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(fakeProductData[2].Name, result.Where(p => p.Name == "TestProd3").FirstOrDefault().Name);
        }
    }
}
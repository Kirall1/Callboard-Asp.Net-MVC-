using System;
using System.Collections.Generic;
using System.Linq;
using CourseProject.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using Moq;
using CourseProject.Models;
using Xunit;
using CourseProject.Models.ViewModels;

namespace CourseProject.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void Can_Use_Repository()
        {
            // Arrange
            Mock<IPlatformRepository> mock = new Mock<IPlatformRepository>();
            mock.Setup(m => m.Ads).Returns((new Ad[] 
            {
                new Ad {AdID = 1, Name = "P1"},
                new Ad {AdID = 2, Name = "P2"}
            }).AsQueryable<Ad>());
            HomeController controller = new HomeController(mock.Object);
            // Act
            AdsListViewModel result = controller.Index(null)?.ViewData.Model as AdsListViewModel ?? new();
            // Assert
            Ad[] adArray = result.Ads.ToArray() ?? Array.Empty<Ad>();
            Assert.True(adArray.Length == 2);
            Assert.Equal("P1", adArray[0].Name);
            Assert.Equal("P2", adArray[1].Name);
        }

        [Fact]
        public void Can_Paginate()
        {
            // Arrange
            Mock<IPlatformRepository> mock = new Mock<IPlatformRepository>();
            mock.Setup(m => m.Ads).Returns((new Ad[] 
            {
                new Ad {AdID = 1, Name = "A1"},
                new Ad {AdID = 2, Name = "A2"},
                new Ad {AdID = 3, Name = "A3"},
                new Ad {AdID = 4, Name = "A4"},
                new Ad {AdID = 5, Name = "A5"}
            }).AsQueryable<Ad>());
            HomeController controller = new HomeController(mock.Object);
            controller.PageSize = 3;
            // Act
            AdsListViewModel result = controller.Index(null, 2)?.ViewData.Model as AdsListViewModel ?? new();
            // Assert
            Ad[] adArray = result.Ads.ToArray();
            Assert.True(adArray.Length == 2);
            Assert.Equal("A4", adArray[0].Name);
            Assert.Equal("A5", adArray[1].Name);
        }

        [Fact]
        public void Can_Send_Pagination_View_Model()
        {
            // Arrange
            Mock<IPlatformRepository> mock = new Mock<IPlatformRepository>();
            mock.Setup(m => m.Ads).Returns((new Ad[] {
                new Ad {AdID = 1, Name = "P1"},
                new Ad {AdID = 2, Name = "P2"},
                new Ad {AdID = 3, Name = "P3"},
                new Ad {AdID = 4, Name = "P4"},
                new Ad {AdID = 5, Name = "P5"}
                }).AsQueryable<Ad>());
            // Arrange
            HomeController controller = new HomeController(mock.Object) { PageSize = 3 };
            // Act
            AdsListViewModel result = controller.Index(null, 2)?.ViewData.Model as AdsListViewModel ?? new();
            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.Equal(2, pageInfo.CurrentPage);
            Assert.Equal(3, pageInfo.ItemsPerPage);
            Assert.Equal(5, pageInfo.TotalItems);
            Assert.Equal(2, pageInfo.TotalPages);
        }

        [Fact]
        public void Can_Filter_Products()
        {
            // Arrange
            // - create the mock repository
            Mock<IPlatformRepository> mock = new Mock<IPlatformRepository>();
            mock.Setup(m => m.Ads).Returns((new Ad[]
            {
                new Ad {AdID = 1, Name = "A1", Category = "Cat1"},
                new Ad {AdID = 2, Name = "A2", Category = "Cat2"},
                new Ad {AdID = 3, Name = "A3", Category = "Cat1"},
                new Ad {AdID = 4, Name = "A4", Category = "Cat2"},
                new Ad {AdID = 5, Name = "A5", Category = "Cat3"}
                }).AsQueryable<Ad>());
            // Arrange - create a controller and make the page size 3 items
            HomeController controller = new HomeController(mock.Object);
            controller.PageSize = 3;
            // Action
            Ad[] result = (controller.Index("Cat2", 1)?.ViewData.Model
            as AdsListViewModel ?? new()).Ads.ToArray();
            // Assert
            Assert.Equal(2, result.Length);
            Assert.True(result[0].Name == "A2" && result[0].Category == "Cat2");
            Assert.True(result[1].Name == "A4" && result[1].Category == "Cat2");
        }
    }
}

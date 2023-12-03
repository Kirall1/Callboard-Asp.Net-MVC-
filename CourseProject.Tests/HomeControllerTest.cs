using System;
using System.Collections.Generic;
using System.Linq;
using CourseProject.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using Moq;
using CourseProject.Controllers;
using CourseProject.Models;
using Xunit;
namespace SportsStore.Tests
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
            IEnumerable<Ad>? result = (controller.Index() as ViewResult)?.ViewData.Model
            as IEnumerable<Ad>;
            // Assert
            Ad[] prodArray = result?.ToArray() ?? Array.Empty<Ad>();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("P1", prodArray[0].Name);
            Assert.Equal("P2", prodArray[1].Name);
        }
    }
}

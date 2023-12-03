using System.Linq;
using CourseProject.Components;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore.Migrations;
using Moq;
using CourseProject.Models;
using Xunit;
using CourseProject.Controllers;
using Microsoft.AspNetCore.Mvc;
using CourseProject.Models.ViewModels;

namespace CourseProject.Tests
{
    public class NavigationMenuViewComponentTests
    {
        [Fact]
        public void Can_Select_Categories()
        {
            // Arrange
            Mock<IPlatformRepository> mock = new Mock<IPlatformRepository>();
            mock.Setup(m => m.Ads).Returns((new Ad[] 
            {
                new Ad {AdID = 1, Name = "A1", Category = "Apples"},
                new Ad {AdID = 2, Name = "A2", Category = "Apples"},
                new Ad {AdID = 3, Name = "A3", Category = "Plums"},
                new Ad {AdID = 4, Name = "A4", Category = "Oranges"},
                }).AsQueryable<Ad>());
            NavigationMenuViewComponent target = new NavigationMenuViewComponent(mock.Object);
            // Act = get the set of categories
            string[] results = ((IEnumerable<string>?)(target.Invoke() 
                as ViewViewComponentResult)?.ViewData?.Model ?? Enumerable.Empty<string>()).ToArray();
            // Assert
            Assert.True(Enumerable.SequenceEqual(new string[] { "Apples", "Oranges", "Plums" }, results));
        }

        [Fact]
        public void Indicates_Selected_Category()
        {
            // Arrange
            string categoryToSelect = "Apples";
            Mock<IPlatformRepository> mock = new Mock<IPlatformRepository>();
            mock.Setup(m => m.Ads).Returns((new Ad[] 
            {
                new Ad {AdID = 1, Name = "A1", Category = "Apples"},
                new Ad {AdID = 4, Name = "A2", Category = "Oranges"},
                }).AsQueryable<Ad>());
            NavigationMenuViewComponent target = new NavigationMenuViewComponent(mock.Object);
            target.ViewComponentContext = new ViewComponentContext
            {
                ViewContext = new ViewContext
                {
                    RouteData = new Microsoft.AspNetCore.Routing.RouteData()
                }
            };
            target.RouteData.Values["category"] = categoryToSelect;
            // Action
            string? result = (string?)(target.Invoke() as ViewViewComponentResult)?.ViewData?["SelectedCategory"];
            // Assert
            Assert.Equal(categoryToSelect, result);
        }


        [Fact]
        public void Generate_Category_Specific_Product_Count()
        {
            // Arrange
            Mock<IPlatformRepository> mock = new Mock<IPlatformRepository>();
            mock.Setup(m => m.Ads).Returns((new Ad[] 
            {
                new Ad {AdID = 1, Name = "A1", Category = "Cat1"},
                new Ad {AdID = 2, Name = "A2", Category = "Cat2"},
                new Ad {AdID = 3, Name = "A3", Category = "Cat1"},
                new Ad {AdID = 4, Name = "A4", Category = "Cat2"},
                new Ad {AdID = 5, Name = "A5", Category = "Cat3"}
                }).AsQueryable<Ad>());
            HomeController target = new HomeController(mock.Object);
            target.PageSize = 3;
            Func<ViewResult, AdsListViewModel?> GetModel = result => result?.ViewData?.Model as AdsListViewModel;
            // Action
            int? res1 = GetModel(target.Index("Cat1"))?.PagingInfo.TotalItems;
            int? res2 = GetModel(target.Index("Cat2"))?.PagingInfo.TotalItems;
            int? res3 = GetModel(target.Index("Cat3"))?.PagingInfo.TotalItems;
            int? resAll = GetModel(target.Index(null))?.PagingInfo.TotalItems;
            // Assert
            Assert.Equal(2, res1);
            Assert.Equal(2, res2);
            Assert.Equal(1, res3);
            Assert.Equal(5, resAll);
        }


    }
}

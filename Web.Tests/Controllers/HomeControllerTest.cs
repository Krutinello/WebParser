using Bll.DTO;
using Bll.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Web.Mvc;
using Web.Controllers;

namespace Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        Mock<IParserService> _parserService;

        [TestInitialize]
        public  void TestInitialize()
        {
            _parserService = new Mock<IParserService>();
            _parserService.Setup(a => a.GetAllProducts()).Returns(new List<ProductDTO>());
        }

        [TestMethod]
        public void ProductsViewModelNotNull()
        {
            // Arrange
            HomeController controller = new HomeController(_parserService.Object);

            // Act
            ViewResult result = controller.Products() as ViewResult;

            // Assert
            Assert.IsNotNull(result.Model);
        }

        //[TestMethod]
        //public void ParseProducts()
        //{
        //    // Arrange
        //    var mock = new Mock<IParserService>();
        //    mock.Setup(a => a.Parse()).Returns(new List<ProductDTO>());
        //    HomeController controller = new HomeController(mock.Object);

        //    // Act
        //    ViewResult result = controller.Products() as ViewResult;

        //    // Assert
        //    Assert.IsNotNull(result.Model);
        //}
    }
}

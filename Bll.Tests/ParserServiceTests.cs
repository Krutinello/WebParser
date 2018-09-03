using Bll.DTO;
using Bll.Interfaces;
using Bll.Service;
using Dal.Entities;
using Dal.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Bll.Tests
{
    [TestClass]
    public class ParserServiceTests
    {
        Mock<IParser> _parser;
        Mock<IMapper> _mapper;
        Mock<IUnitOfWork> _uow;

        //[TestInitialize]
        //public void TestInitialize()
        //{
        //    _parser = new Mock<IParser>();
        //    _parser.Setup(a => a.ParsePcShop()).Returns(new List<ProductDTO>());

        //    _mapper = new Mock<IMapper>();
        //    _mapper.Setup(a => a.MapProductsToProductsDTO(new List<Product>())).Returns(new List<ProductDTO>());

        //    _uow = new Mock<IUnitOfWork>();
        //    _uow.Setup(a => a.Products.GetAll()).Returns(new List<Product>());
        //    _uow.Setup(a => a.Products.GetById()).Returns(new Product());
        //}

        //[TestMethod]
        //public void Parse()
        //{
        //    List<Product> products = new List<Product>() {
        //        new Product()
        //        {
        //            Name = "name1",
        //            Description = "desc1",

        //        }
        //    }; 

        //    _parser = new Mock<IParser>();
        //    _parser.Setup(a => a.ParsePcShop()).Returns(new List<ProductDTO>());

        //    _mapper = new Mock<IMapper>();
        //    _mapper.Setup(a => a.MapProductsToProductsDTO(new List<Product>())).Returns(new List<ProductDTO>());

        //    _uow = new Mock<IUnitOfWork>();
        //    _uow.Setup(a => a.Products.GetAll()).Returns(new List<Product>());
        //    _uow.Setup(a => a.Products.Update(new Product()));
        //    _uow.Setup(a => a.Products.Create(new Product()));


        //    ParserService parserService = new ParserService(_uow.Object, _parser.Object, _mapper.Object);

        //    try
        //    {
        //        parserService.Parse();
        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.Fail("Expected no exception, but got: " + ex.Message);
        //    }
        //    Assert.IsTrue(true);          
        //}

        [TestMethod]
        public void SaveImage_ImagePath(string url) {
            _parser = new Mock<IParser>();

            _mapper = new Mock<IMapper>();

            _uow = new Mock<IUnitOfWork>();

            ParserService parserService = new ParserService(_uow.Object, _parser.Object, _mapper.Object);

            url = "http://s1.1zoom.me/big0/930/Coast_Sunrises_and_sunsets_Waves_USA_Ocean_Kaneohe_521540_1280x775.jpg";
            string path = parserService.SaveImage(url);

            Assert.IsNotNull(path);
        }

        [TestMethod]
        public void GetAllProducts_listProductsDto(){
            _parser = new Mock<IParser>();
            _parser.Setup(a => a.ParsePcShop()).Returns(new List<ProductDTO>());

            _mapper = new Mock<IMapper>();
            _mapper.Setup(a => a.MapProductsToProductsDTO(new List<Product>())).Returns(new List<ProductDTO>());

            _uow = new Mock<IUnitOfWork>();
            _uow.Setup(a => a.Products.GetAll()).Returns(new List<Product>());

            ParserService parserService = new ParserService(_uow.Object, _parser.Object, _mapper.Object);

            List<ProductDTO> result = parserService.GetAllProducts();

            Assert.IsNotNull(result);
        }

        //[TestCleanup]
        //public void TestCleanUp()
        //{
            
        //}
    }
}

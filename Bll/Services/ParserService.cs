using Bll.DTO;
using Bll.Infrastructure;
using Bll.Interfaces;
using Dal.Entities;
using Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;

namespace Bll.Service
{
    public class ParserService : IParserService
    {
        IUnitOfWork _uow { get; set; }
        IParser _parser { get; set; }
        IMapper _mapper { get; set; }

        public ParserService(IUnitOfWork uow,IParser parser,IMapper mapper)
        {
            _uow = uow;
            _parser = parser;
            _mapper = mapper;
        }

        public List<ProductDTO> GetAllProducts()/* => _mapper.MapProductsToProductsDTO(_uow.Products.GetAll().ToList());*/
        {
            List<Product> products = _uow.Products.GetAll().ToList();

            if (products == null)
                throw new ValidationException("Bad news", "");

            List<ProductDTO> productsDto = _mapper.MapProductsToProductsDTO(products);

            return productsDto;
        }

        public ProductDTO GetProduct(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id продукта", "");

            var product = _uow.Products.GetById(id.Value);
            if (product == null)
                throw new ValidationException("Продукт не найден", "");
            
            ProductDTO productDto =_mapper.MapProductToProductDTO(product);

            return productDto;
        }

        public void Parse()
        {
            List<ProductDTO> productsDto = _parser.ParsePcShop();
           
            if(productsDto != null && productsDto.Any())
            {
                List<Product> products = _uow.Products.GetAll().ToList();

                foreach(var productDto in productsDto)
                {
                    Product product = products.Where(p => p.Name == productDto.Name && p.Description == productDto.Description).FirstOrDefault();
                    if(product!=null)
                    {
                        ProductPrice price = product.Prices.Where(pr => pr.Price == productDto.Prices.First().Price).FirstOrDefault();

                        if (price == null) { 
                            product.Prices.Add(new ProductPrice() {Price= productDto.Prices.First().Price,Date=DateTime.Now });
                            _uow.Products.Update(product);
                            _uow.Save();
                        }                      
                    }
                    else
                    {
                        Product newProduct = new Product() {
                            Name=productDto.Name,
                            Description=productDto.Description,
                            ImagePath = productDto.ImagePath
                        };

                        newProduct.Prices = new List<ProductPrice>();

                        ProductPrice newPrice = new ProductPrice(){
                            Date=DateTime.Now,
                            Price=productDto.Prices.First().Price};

                        newProduct.Prices.Add(newPrice);

                        newProduct.ImagePath = SaveImage(productDto.ImagePath);

                        _uow.Products.Create(newProduct);
                        _uow.Save();
                    }
                }               
            }
            else
                throw new ValidationException("Bad news", "");
        }

        public string SaveImage(string url)
        {
            try
            {
                WebRequest req = WebRequest.Create(url);
                WebResponse response = req.GetResponse();
                Stream stream = response.GetResponseStream();


                Image img = Image.FromStream(stream);
                stream.Flush();
                stream.Close();

                string fileName = Guid.NewGuid().ToString() + ".jpg";
                string root = HttpContext.Current.Server.MapPath("~/Content/Images/" + fileName);

                img.Save(root, ImageFormat.Jpeg);

                string path = "/Content/Images/" + fileName;

                return path;
            }
            catch(Exception ex)
            {
                throw new ValidationException(ex.Message, "");
            }

        }

        public void Dispose()
        {
            _uow.Dispose();
        }
    }
}

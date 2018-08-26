using Bll.DTO;
using Bll.Interfaces;
using Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Helpers
{
    public class Mapper : IMapper
    {
        public List<ProductDTO> MapProductsToProductsDTO(List<Product> products)
        {
            List<ProductDTO> productsDto = new List<ProductDTO>();
            foreach(var product in products)
            {
                ProductDTO productDto = new ProductDTO() {
                Id=product.Id,
                Name=product.Name,
                Description=product.Description,
                ImagePath=product.ImagePath};
                
                foreach(var price in product.Prices)
                {
                    ProductPriceDTO productPriceDto = new ProductPriceDTO() {
                    Date=price.Date,
                    Price=price.Price};
                    productDto.Prices.Add(productPriceDto);
                }
                productsDto.Add(productDto);
            }

            return productsDto;
        }

        public ProductDTO MapProductToProductDTO(Product product)
        {
            ProductDTO productDto = new ProductDTO()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ImagePath = product.ImagePath
            };

            foreach (var price in product.Prices)
            {
                ProductPriceDTO productPriceDto = new ProductPriceDTO()
                {
                    Date = price.Date,
                    Price = price.Price
                };
                productDto.Prices.Add(productPriceDto);
            }
            return productDto;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.DTO
{
    public class ProductDTO
    {
        public ProductDTO()
        {
            Prices = new List<ProductPriceDTO>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public List<ProductPriceDTO> Prices { get; set; }
    }
}

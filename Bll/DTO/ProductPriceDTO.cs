using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.DTO
{
    public class ProductPriceDTO
    {
        public int Id { get; set; }

        public string Price { get; set; }

        public DateTime Date { get; set; }

        public int ProductId { get; set; }

        //public ProductDTO Product { get; set; }
    }
}

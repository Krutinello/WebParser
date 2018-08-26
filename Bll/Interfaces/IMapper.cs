using Bll.DTO;
using Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Interfaces
{
    public interface IMapper
    {
        List<ProductDTO> MapProductsToProductsDTO(List<Product> products);
        ProductDTO MapProductToProductDTO(Product products);
    }
}

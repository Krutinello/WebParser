using Bll.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Interfaces
{
    public interface IScraper
    {
        List<ProductDTO> Scrap(string url);
    }
}

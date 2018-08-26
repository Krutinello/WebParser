using Dal.Entities;
using System.Data.Entity;

namespace Dal.EF
{
    public class WebParserContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<ProductPrice> ProductPrices { get; set; }

        public WebParserContext(string connectionString)
            : base (connectionString)
        {
        }
    }
}

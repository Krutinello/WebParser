using Dal.EF;
using Dal.Entities;
using Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private WebParserContext db;
        private ProductRepository productRepository;
        private ProductPriceRepository productPriceRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new WebParserContext(connectionString);
        }

        public IRepository<Product> Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(db);

                return productRepository;
            }
        }
        public IRepository<ProductPrice> ProductPrices
        {
            get
            {
                if (productPriceRepository == null)
                    productPriceRepository = new ProductPriceRepository(db);

                return productPriceRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose( bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

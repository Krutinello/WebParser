using Dal.EF;
using Dal.Entities;
using Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Dal.Repositories
{
    public class ProductPriceRepository : IRepository<ProductPrice>
    {
        private WebParserContext db;

        public ProductPriceRepository(WebParserContext context)
        {
            this.db = context;
        }

        public IEnumerable<ProductPrice> GetAll()
        {
            return db.ProductPrices;
        }

        public ProductPrice GetById(int id)
        {
            return db.ProductPrices.Find(id);
        }

        public void Create(ProductPrice price)
        {
            db.ProductPrices.Add(price);
        }

        public void Update(ProductPrice price)
        {
            db.Entry(price).State = EntityState.Modified;
        }

        public IEnumerable<ProductPrice> Find(Func<ProductPrice, Boolean> predicate)
        {
            return db.ProductPrices.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            ProductPrice price = db.ProductPrices.Find(id);
            if (price != null)
                db.ProductPrices.Remove(price);
        }
    }
}

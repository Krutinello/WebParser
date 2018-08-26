using Dal.EF;
using Dal.Entities;
using Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Dal.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private WebParserContext db;

        public ProductRepository(WebParserContext context)
        {
            this.db = context;
        }

        public IEnumerable<Product> GetAll() => db.Products.Include(p=>p.Prices);

        public Product GetById(int id) => db.Products.Include(p => p.Prices).Where(p=>p.Id == id).FirstOrDefault();

        public void Create(Product product) => db.Products.Add(product);

        public void Update(Product product) => db.Entry(product).State = EntityState.Modified;

        public IEnumerable<Product> Find(Func<Product, Boolean> predicate) => db.Products.Include(p=>p.Prices).Where(predicate).ToList();

        public void Delete(int id)
        {
            Product product = db.Products.Find(id);
            if (product != null)
                db.Products.Remove(product);
        }
    }
}

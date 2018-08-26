using Dal.Entities;
using System;

namespace Dal.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get; }

        IRepository<ProductPrice> ProductPrices { get; }

        void Save();

    }
}

using Bll.Helpers;
using Bll.Interfaces;
using Dal.Interfaces;
using Dal.Repositories;
using Ninject.Modules;

namespace Bll.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
            Bind<IParser>().To<PcShopParser>();
            Bind<IMapper>().To<Mapper>();
        }
    }
}

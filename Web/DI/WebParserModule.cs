using Bll.Interfaces;
using Bll.Service;
using Ninject.Modules;

namespace Web.DI
{
    public class WebParserModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IParserService>().To<ParserService>();
        }
    }
}
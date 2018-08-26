using Bll.Interfaces;
using System.Net;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        IParserService _parserService;
        public HomeController(IParserService service)
        {
            _parserService = service;
        }

        public ActionResult Index() =>View();

        public ActionResult Parser()
        {
            _parserService.Parse();
            return Redirect("/Home/Products");
        }
        public ActionResult Products() => View(_parserService.GetAllProducts());

        public ActionResult Product(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return View(_parserService.GetProduct(id.Value));
        }
    }
}
using System.Web.Mvc;

namespace Epam.Wunderlist.Web.Controllers
{
    [HandleError()]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }     

        [Authorize]
        public ActionResult WebApp()
        {
            return View();
        }
    }
}
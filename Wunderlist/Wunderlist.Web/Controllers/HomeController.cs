using System.Web.Mvc;

namespace Epam.Wunderlist.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }     
    }
}
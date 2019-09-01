using System.Web.Mvc;

namespace ChartApi.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Homepage");
        }
    }
}
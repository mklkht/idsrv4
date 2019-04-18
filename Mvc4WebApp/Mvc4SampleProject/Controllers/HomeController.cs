using System.Web.Mvc;

namespace Mvc4SampleProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "POC Web Aplication";

            return View();
        }

        [Authorize]
        public ActionResult Secret()
        {
            ViewBag.Message = "Secret page";

            return View();
        }
    }
}

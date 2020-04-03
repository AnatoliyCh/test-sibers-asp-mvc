using BusinessLogicLayer.Services;
using System.Web.Mvc;

namespace _2_PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        protected override void Dispose(bool disposing) => base.Dispose(disposing);
    }
}
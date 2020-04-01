using DataAccessLayer.DataBase;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace _2_PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        private ProjectDataContext db = new ProjectDataContext();

        public ActionResult Index()
        {
            var projects = db.Projects.Include(p => p.ProjectManager);
            return View(db.Employees.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            Employee employee = db.Employees.Find(id);

            if (employee == null) return HttpNotFound();
            return View(employee);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
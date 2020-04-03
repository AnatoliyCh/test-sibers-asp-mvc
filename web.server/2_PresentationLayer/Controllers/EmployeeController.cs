using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Services;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeService employeeService = new EmployeeService();

        // GET: Employee
        public ActionResult Index()
        {
            return View(employeeService.GetEmployees());
        }
        // GET: Employee/Details/5
        public ActionResult Details(int id = 1)
        {
            EmployeeDTO employee = employeeService.GetEmployee(id);
            if (employee == null) return HttpNotFound();
            return View(employee);
        }
        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(EmployeeDTO employeeDTO)
        {
            try
            {
                employeeService.CreateEmployee(employeeDTO);
                employeeService.SaveEmployee();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Employee/Edit/5
        public ActionResult Edit(int id = 1)
        {
            EmployeeDTO employee = employeeService.GetEmployee(id);
            if (employee == null) return HttpNotFound();
            return View(employee);
        }
        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(EmployeeDTO employeeDTO)
        {
            try
            {
                if (employeeDTO != null)
                {
                    employeeService.UpdateEmployee(employeeDTO);
                    employeeService.SaveEmployee();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            EmployeeDTO employee = employeeService.GetEmployee(id);
            if (employee == null) return HttpNotFound();
            return View(employee);
        }
        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(EmployeeDTO employeeDTO)
        {
            try
            {
                if (employeeDTO != null)
                {
                    employeeService.DeleteEmployee(employeeDTO);
                    employeeService.SaveEmployee();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        protected override void Dispose(bool disposing)
        {
            employeeService.Dispose();
            base.Dispose(disposing);
        }
    }
}
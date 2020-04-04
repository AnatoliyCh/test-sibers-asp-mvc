using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class ProjectController : Controller
    {
        private ProjectService projectService = new ProjectService();
        private EmployeeService employeeService = new EmployeeService();

        // GET: Project
        public ActionResult Index()
        {
            return View(projectService.GetProjects());
        }
        // GET: Project/Details/5
        public ActionResult Details(int id = 1)
        {
            ProjectDTO project = projectService.GetProject(id);
            if (project == null) return HttpNotFound();
            return View(project);
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            var employees = employeeService.GetEmployees();
            if (employees != null && employees.Count() > 0) ViewBag.Employees = employees;
            return View(new ProjectDTO());
        }
        [HttpPost] // POST: Project/Create
        public ActionResult Create(ProjectDTO projectDTO, int[] selectedEmployees = null, int[] selectedExecutors = null)
        {
            try
            {
                if (projectDTO.EndDate < projectDTO.StartDate)
                    ModelState.AddModelError("StartDate", "Дата начала меньше даты окончания");
                if (projectDTO.Priority < 0)
                    ModelState.AddModelError("Priority", "Приоритет меньше 0");
                if (!ModelState.IsValid) throw new Exception(); // не прошли валидацию

                projectService.CreateProject(projectDTO, selectedEmployees, selectedExecutors);
                projectService.SaveProject();
                return RedirectToAction("Index");
            }
            catch
            {
                var employees = employeeService.GetEmployees();
                projectDTO.Employees = (IList<EmployeeDTO>)employeeService.GetEmployees(selectedEmployees, employees);
                projectDTO.Executors = (IList<EmployeeDTO>)employeeService.GetEmployees(selectedExecutors, employees);
                if (employees != null && employees.Count() > 0) ViewBag.Employees = employees;
                return View(projectDTO);
            }
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int id = 1)
        {
            ProjectDTO project = projectService.GetProject(id);
            if (project == null) return HttpNotFound();
            var employees = employeeService.GetEmployees();
            if (employees != null && employees.Count() > 0)
            {
                project = projectService.ProjectBind(project, employees);
                ViewBag.Employees = employees;
            }
            return View(project);
        }
        [HttpPost] // POST: Project/Edit/5
        public ActionResult Edit(ProjectDTO projectDTO, int[] selectedEmployees = null, int[] selectedExecutors = null)
        {
            try
            {
                if (projectDTO.EndDate < projectDTO.StartDate)
                    ModelState.AddModelError("StartDate", "Дата начала меньше даты окончания");
                if (projectDTO.Priority < 0)
                    ModelState.AddModelError("Priority", "Приоритет меньше 0");
                if (!ModelState.IsValid) throw new Exception(); // не прошли валидацию

                projectService.UpdateProject(projectDTO, selectedEmployees, selectedExecutors);
                projectService.SaveProject();
                return RedirectToAction("Index");
            }
            catch
            {
                var employees = employeeService.GetEmployees();
                projectDTO.Employees = (IList<EmployeeDTO>)employeeService.GetEmployees(selectedEmployees, employees);
                projectDTO.Executors = (IList<EmployeeDTO>)employeeService.GetEmployees(selectedExecutors, employees);
                if (employees != null && employees.Count() > 0) ViewBag.Employees = employees;
                return View(projectDTO);
            }
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            ProjectDTO project = projectService.GetProject(id);
            if (project == null) return HttpNotFound();
            return View(project);
        }
        [HttpPost]// POST: Project/Delete/5
        public ActionResult Delete(ProjectDTO projectDTO)
        {
            try
            {
                if (projectDTO != null)
                {
                    projectService.DeleteProject(projectDTO);
                    projectService.SaveProject();
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
            projectService.Dispose();
            base.Dispose(disposing);
        }
    }
}

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
            return View();
        }        
        [HttpPost] // POST: Project/Create
        public ActionResult Create(ProjectDTO projectDTO)
        {
            try
            {
                projectService.CreateProject(projectDTO);
                projectService.SaveProject();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        // GET: Project/Edit/5
        public ActionResult Edit(int id = 1)
        {
            ProjectDTO project = projectService.GetProject(id);
            if (project == null) return HttpNotFound();
            return View(project);
        }        
        [HttpPost] // POST: Project/Edit/5
        public ActionResult Edit(ProjectDTO projectDTO)
        {
            try
            {
                if (projectDTO != null)
                {
                    projectService.UpdateProject(projectDTO);
                    projectService.SaveProject();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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

using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services
{
    public class ProjectService : IProjectService
    {
        IUnitOfWork DataBase { get; set; }

        public ProjectService(IUnitOfWork dataBase) => DataBase = dataBase;

        public Project GetProject(int id)
        {
            return DataBase.Projects.Get(id);
        }
        public IEnumerable<Project> GetProjects()
        {
            return DataBase.Projects.GetAll();
        }
        public void CreateProject(Project project) => DataBase.Projects.Create(project);
        public void SaveProject() => DataBase.Save();
        public void Dispose() => DataBase.Dispose();
    }
}
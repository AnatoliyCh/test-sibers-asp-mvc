using DataAccessLayer.Models;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface IProjectService
    {
        Project GetProject(int id);
        IEnumerable<Project> GetProjects();
        void CreateProject(Project project);
        void SaveProject();
        void Dispose();
    }
}
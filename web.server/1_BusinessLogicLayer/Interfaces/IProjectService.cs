using BusinessLogicLayer.DTO;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface IProjectService
    {
        ProjectDTO GetProject(int id);
        IEnumerable<ProjectDTO> GetProjects();
        void CreateProject(ProjectDTO dto);
        void SaveProject();
        void UpdateProject(ProjectDTO dto);
        void DeleteProject(ProjectDTO dto);
        void Dispose();
    }
}
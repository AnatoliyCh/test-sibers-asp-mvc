using BusinessLogicLayer.DTO;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface IProjectService
    {
        ProjectDTO GetProject(int id);
        IEnumerable<ProjectDTO> GetProjects();
        void CreateProject(ProjectDTO dto, int[] selectedEmployees = null, int[] selectedExecutors = null);
        void SaveProject();
        void UpdateProject(ProjectDTO dto);
        void DeleteProject(ProjectDTO dto);
        /// <summary> замены ссылок у DTO на объекты из новой коллекции </summary>
        ProjectDTO ProjectBind(ProjectDTO dto, IEnumerable<EmployeeDTO> employeesDTO);
        void Dispose();
    }
}
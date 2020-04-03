using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mappers;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IMapperEmployee mapperEmployee = new MapperEmployee();
        private readonly IMapperProject mapperProject = new MapperProject();
        IUnitOfWork DataBase { get; set; }

        public ProjectService() => DataBase = new UnitOfWork();
        public ProjectService(IUnitOfWork dataBase) => DataBase = dataBase;
        public ProjectDTO GetProject(int id)
        {
            var project = DataBase.Projects.Get(id);
            if (project != null)
            {
                var newDTO = mapperProject.GetDTO(project);
                // сборка внешних зависимостей
                if (project.Employees.Count > 0) newDTO.Employees = (ICollection<EmployeeDTO>)mapperEmployee.GetDTOs(project.Employees);
                if (project.Executors.Count > 0) newDTO.Executors = (ICollection<EmployeeDTO>)mapperEmployee.GetDTOs(project.Executors);
                if (project.ProjectManagerId != null && project.ProjectManager != null) newDTO.ProjectManager = mapperEmployee.GetDTO(project.ProjectManager);
                return newDTO;
            }
            return null;
        }
        public IEnumerable<ProjectDTO> GetProjects()
        {
            var projects = (IList<Project>)DataBase.Projects.GetAll();
            if (projects != null)
            {
                var dtos = (IList<ProjectDTO>)mapperProject.GetDTOs(projects);
                // сборка внешних зависимостей
                for (int i = 0; i < projects.Count; i++)
                    if (projects[i].ProjectManagerId != null && projects[i].ProjectManager != null) 
                        dtos[i].ProjectManager = mapperEmployee.GetDTO(projects[i].ProjectManager);
                return dtos;
            }
            return null;
        }
        public void CreateProject(ProjectDTO dto)
        {
            if (dto != null)
            {
                var newProject = mapperProject.GetModel(dto);
                // сборка внешних зависимостей
                if (newProject.Employees.Count > 0) newProject.Employees = (ICollection<Employee>)mapperEmployee.GetModels(dto.Employees);
                if (newProject.Executors.Count > 0) newProject.Executors = (ICollection<Employee>)mapperEmployee.GetModels(dto.Executors);
                if (dto.ProjectManager != null)
                {
                    newProject.ProjectManager = mapperEmployee.GetModel(dto.ProjectManager);
                    newProject.ProjectManagerId = newProject.ProjectManager.Id;
                }
                DataBase.Projects.Create(newProject);
            }
        }
        public void UpdateProject(ProjectDTO dto)
        {
            if (dto != null) DataBase.Projects.Update(mapperProject.GetModel(dto));
        }
        public void DeleteProject(ProjectDTO dto)
        {
            if (dto != null) DataBase.Projects.Delete(dto.Id);
        }
        public void SaveProject() => DataBase.Save();
        public void Dispose() => DataBase.Dispose();
    }
}
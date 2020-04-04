using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Infrastructure.Comparers;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mappers;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IMapperEmployee mapperEmployee = new MapperEmployee();
        private readonly IMapperProject mapperProject = new MapperProject();
        public IUnitOfWork DataBase { get; set; }

        private IEqualityComparer<EmployeeDTO> employeeDTOEqualityComparer = new EmployeeDTOEqualityComparer();

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
                if (project.ProjectManagerId != null && project.ProjectManager != null) newDTO.ProjectManagerId = project.ProjectManagerId;
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
        public void CreateProject(ProjectDTO dto, int[] selectedEmployees, int[] selectedExecutors)
        {
            if (dto != null)
            {
                var newProject = mapperProject.GetNewModel(dto);
                newProject = ModelBindExternalDependencies(newProject, selectedEmployees, selectedExecutors); // сборка внешних зависимостей
                DataBase.Projects.Create(newProject);
            }
        }
        public void UpdateProject(ProjectDTO dto)
        {
            if (dto != null) DataBase.Projects.Update(mapperProject.GetNewModel(dto));
        }
        public void UpdateProject(ProjectDTO dto, int[] selectedEmployees, int[] selectedExecutors)
        {
            if (dto != null)
            {
                Project newProject = mapperProject.GetNewModel(dto);
                newProject = ModelBindExternalDependencies(newProject, selectedEmployees, selectedExecutors);
                DataBase.Projects.Update(newProject, newProject.Id, new string[] { "Employees", "Executors" });
            }
        }
        public void DeleteProject(ProjectDTO dto)
        {
            if (dto != null) DataBase.Projects.Delete(dto.Id);
        }
        public void SaveProject() => DataBase.Save();
        public ProjectDTO ProjectBind(ProjectDTO dto, IEnumerable<EmployeeDTO> employeesDTO)
        {
            if (employeesDTO != null && dto.Employees != null && dto.Executors != null)
            {
                IList<EmployeeDTO> newEmployees = new List<EmployeeDTO>();
                IList<EmployeeDTO> newExecutors = new List<EmployeeDTO>();
                foreach (var employeeDTO in employeesDTO)
                {
                    // работники
                    foreach (var employee in dto.Employees)
                        if (employeeDTO.Id == employee.Id) newEmployees.Add(employeeDTO);
                    // исполнители
                    foreach (var executor in dto.Executors)
                        if (employeeDTO.Id == executor.Id) newExecutors.Add(employeeDTO);
                }
                if (newEmployees.Count > 0) dto.Employees = newEmployees;
                if (newExecutors.Count > 0) dto.Executors = newExecutors;
            }
            return dto;
        }
        public IEnumerable<EmployeeDTO> Union(IEnumerable<EmployeeDTO> first, IEnumerable<EmployeeDTO> second)
        {
            return first.Union(second, employeeDTOEqualityComparer);
        }
        public void Dispose() => DataBase.Dispose();

        /// <summary> сборка модели для сохранения/обновления в БД </summary>
        private Project ModelBindExternalDependencies(Project model, int[] selectedEmployees, int[] selectedExecutors)
        {
            // работники
            if (selectedEmployees != null && selectedEmployees.Length > 0)
            {
                foreach (var id in selectedEmployees)
                    model.Employees.Add(DataBase.Employees.Get(id));
            }
            // исполнители
            if (selectedExecutors != null && selectedExecutors.Length > 0)
            {
                foreach (var id in selectedExecutors)
                    model.Executors.Add(DataBase.Employees.Get(id));
            }
            // руководитель
            if (model.ProjectManagerId != null)
            {
                var tmpProjectManager = DataBase.Employees.Get((int)model.ProjectManagerId);
                if (tmpProjectManager != null) model.ProjectManager = tmpProjectManager;
            }
            return model;
        }
    }
}
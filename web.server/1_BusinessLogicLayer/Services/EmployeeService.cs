using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mappers;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapperEmployee mapperEmployee = new MapperEmployee();
        private readonly IMapperProject mapperProject = new MapperProject();
        public IUnitOfWork DataBase { get; set; }

        public EmployeeService() => DataBase = new UnitOfWork();
        public EmployeeService(IUnitOfWork dataBase) => DataBase = dataBase;
        public EmployeeDTO GetEmployee(int id)
        {
            var employee = DataBase.Employees.Get(id);
            if (employee != null)
            {
                var newDTO = mapperEmployee.GetDTO(employee);
                // сборка внешних зависимостей
                if (employee.EmployeeInProjects.Count > 0) newDTO.EmployeeInProjects = (ICollection<ProjectDTO>)mapperProject.GetDTOs(employee.EmployeeInProjects);
                if (employee.ExecutorInProjects.Count > 0) newDTO.ExecutorInProjects = (ICollection<ProjectDTO>)mapperProject.GetDTOs(employee.ExecutorInProjects);
                return newDTO;
            }
            return null;
        }
        public IEnumerable<EmployeeDTO> GetEmployees()
        {
            var employees = DataBase.Employees.GetAll();
            if (employees != null) return mapperEmployee.GetDTOs(employees);
            return null;
        }
        public void CreateEmployee(EmployeeDTO dto)
        {
            if (dto != null)
            {
                var newEmployee = mapperEmployee.GetModel(dto);
                // сборка внешних зависимостей
                if (dto.EmployeeInProjects.Count > 0) newEmployee.EmployeeInProjects = (ICollection<Project>)mapperProject.GetModels(dto.EmployeeInProjects);
                if (dto.ExecutorInProjects.Count > 0) newEmployee.ExecutorInProjects = (ICollection<Project>)mapperProject.GetModels(dto.ExecutorInProjects);
                DataBase.Employees.Create(newEmployee);
            }
        }
        public void SaveEmployee() => DataBase.Save();
        public void Dispose() => DataBase.Dispose();
    }
}
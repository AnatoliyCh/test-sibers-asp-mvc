using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mappers;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repository;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapperEmployee mapperEmployee = new MapperEmployee();
        public IUnitOfWork DataBase { get; set; }

        public EmployeeService() => DataBase = new UnitOfWork();
        public EmployeeService(IUnitOfWork dataBase) => DataBase = dataBase;

        public EmployeeDTO GetEmployee(int id)
        {
            var employee = DataBase.Employees.Get(id);
            if (employee != null) return mapperEmployee.GetDTO(employee);
            return null;
        }
        public IEnumerable<EmployeeDTO> GetEmployees()
        {
            var employees = DataBase.Employees.GetAll();
            if (employees != null) return mapperEmployee.GetDTOs(employees);
            return null;
        }
        public void CreateEmployee(EmployeeDTO employee)
        {
            if (employee != null)
            {
                var newEmployee = mapperEmployee.GetModel(employee);
                DataBase.Employees.Create(newEmployee);
            }
        }
        public void SaveEmployee() => DataBase.Save();
        public void Dispose() => DataBase.Dispose();
    }
}
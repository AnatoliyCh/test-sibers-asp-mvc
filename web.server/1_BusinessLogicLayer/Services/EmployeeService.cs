using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        IUnitOfWork DataBase { get; set; }

        public EmployeeService(IUnitOfWork dataBase) => DataBase = dataBase;

        public Employee GetEmployee(int id)
        {
            return DataBase.Employees.Get(id);
        }
        public IEnumerable<Employee> GetEmployees()
        {
            return DataBase.Employees.GetAll();
        }
        public void CreateEmployee(Employee employee) => DataBase.Employees.Create(employee);
        public void SaveEmployee() => DataBase.Save();
        public void Dispose() => DataBase.Dispose();
    }
}
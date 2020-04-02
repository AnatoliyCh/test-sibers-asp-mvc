using DataAccessLayer.Models;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface IEmployeeService
    {
        Employee GetEmployee(int id);
        IEnumerable<Employee> GetEmployees();
        void CreateEmployee(Employee employee);
        void SaveEmployee();
        void Dispose();
    }
}
﻿using BusinessLogicLayer.DTO;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface IEmployeeService
    {
        EmployeeDTO GetEmployee(int id);
        /// <summary> получает всех работников </summary>
        IEnumerable<EmployeeDTO> GetEmployees();
        /// <summary> получает работников из employees с id из idEmployees </summary>
        IEnumerable<EmployeeDTO> GetEmployees(int[] idEmployees, IEnumerable<EmployeeDTO> employeesDTOs);
        void CreateEmployee(EmployeeDTO dto);        
        void UpdateEmployee(EmployeeDTO dto);
        void DeleteEmployee(EmployeeDTO dto);
        void SaveEmployee();
        IEnumerable<EmployeeDTO> Union(IEnumerable<EmployeeDTO> first, IEnumerable<EmployeeDTO> second);
        IEnumerable<ProjectDTO> ManagerProjects(int managerId, IEnumerable<ProjectDTO> projectDTOs);
        void Dispose();
    }
}
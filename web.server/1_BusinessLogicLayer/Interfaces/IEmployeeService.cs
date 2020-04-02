﻿using BusinessLogicLayer.DTO;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface IEmployeeService
    {
        EmployeeDTO GetEmployee(int id);
        IEnumerable<EmployeeDTO> GetEmployees();
        void CreateEmployee(EmployeeDTO dto);
        void SaveEmployee();
        void Dispose();
    }
}
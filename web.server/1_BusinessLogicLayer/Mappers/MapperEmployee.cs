using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Mappers
{
    public class MapperEmployee : IMapperEmployee
    {
        public EmployeeDTO GetDTO(Employee model)
        {
            return new EmployeeDTO
            {
                Id = model.Id,
                LastName = model.LastName,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                Email = model.Email,
                EmployeeInProjects = model.EmployeeInProjects.Count,
                ExecutorInProjects = model.ExecutorInProjects.Count,
            };
        }
        public Employee GetModel(EmployeeDTO dto)
        {
            return new Employee
            {
                Id = dto.Id,
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                MiddleName = dto.MiddleName,
                Email = dto.Email,
                EmployeeInProjects = new List<Project>(),
                ExecutorInProjects = new List<Project>(),
            };
        }
        public IEnumerable<EmployeeDTO> GetDTOs(IEnumerable<Employee> models)
        {
            IList<EmployeeDTO> dtos = new List<EmployeeDTO>();
            foreach (var item in models) dtos.Add(GetDTO(item));
            return dtos;
        }
        public IEnumerable<Employee> GetModels(IEnumerable<EmployeeDTO> dtos)
        {
            IList<Employee> models = new List<Employee>();
            foreach (var item in dtos) models.Add(GetModel(item));
            return models;
        }
    }
}

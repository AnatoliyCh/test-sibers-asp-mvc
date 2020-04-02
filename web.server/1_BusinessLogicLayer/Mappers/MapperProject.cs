using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Mappers
{
    public class MapperProject : IMapperProject
    {
        public ProjectDTO GetDTO(Project model)
        {
            return new ProjectDTO
            {
                Id = model.Id,
                Name = model.Name,
                CustomerName = model.CustomerName,
                ExecutingCompany = model.ExecutingCompany,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Priority = model.Priority,
            };
        }
        public Project GetModel(ProjectDTO dto)
        {
            return new Project
            {
                Id = dto.Id,
                Name = dto.Name,
                CustomerName = dto.CustomerName,
                ExecutingCompany = dto.ExecutingCompany,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Priority = dto.Priority,
            };
        }
        public IEnumerable<ProjectDTO> GetDTOs(IEnumerable<Project> models)
        {
            ICollection<ProjectDTO> dtos = new List<ProjectDTO>();
            foreach (var item in models) dtos.Add(GetDTO(item));
            return dtos;
        }        
        public IEnumerable<Project> GetModels(IEnumerable<ProjectDTO> dtos)
        {
            ICollection<Project> models = new List<Project>();
            foreach (var item in dtos) models.Add(GetModel(item));
            return models;
        }
    }
}

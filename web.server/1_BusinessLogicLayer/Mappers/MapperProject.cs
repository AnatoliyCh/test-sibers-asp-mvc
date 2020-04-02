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
            throw new NotImplementedException();
        }

        public IEnumerable<ProjectDTO> GetDTOs(IEnumerable<Project> models)
        {
            throw new NotImplementedException();
        }

        public Project GetModel(ProjectDTO model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetModels(IEnumerable<ProjectDTO> models)
        {
            throw new NotImplementedException();
        }
    }
}

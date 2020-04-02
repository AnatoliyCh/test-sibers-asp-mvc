using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO
{
    public class EmployeeDTO
    {
        public EmployeeDTO()
        {
            EmployeeInProjects = new List<ProjectDTO>();
            ExecutorInProjects = new List<ProjectDTO>();
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public ICollection<ProjectDTO> EmployeeInProjects { get; set; } // проекты в которых сотрудник
        public ICollection<ProjectDTO> ExecutorInProjects { get; set; } // проекты в которых исполнитель
    }
}

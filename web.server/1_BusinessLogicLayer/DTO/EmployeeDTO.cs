using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Фамилия")] public string LastName { get; set; }
        [Display(Name = "Имя")] public string FirstName { get; set; }
        [Display(Name = "Отчество")] public string MiddleName { get; set; }
        [Display(Name = "E-mail")] public string Email { get; set; }
        [Display(Name = "Сотрудник в ")] public ICollection<ProjectDTO> EmployeeInProjects { get; set; } // проекты в которых сотрудник
        [Display(Name = "Исполнитель в ")] public ICollection<ProjectDTO> ExecutorInProjects { get; set; } // проекты в которых исполнитель
    }
}

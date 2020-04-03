using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO
{
    public class ProjectDTO
    {
        public ProjectDTO()
        {
            Employees = new List<EmployeeDTO>();
            Executors = new List<EmployeeDTO>();
        }

        public int Id { get; set; }
        [Display(Name = "Название")] public string Name { get; set; }
        [Display(Name = "Компания-заказчик")] public string CustomerName { get; set; } // компания-заказчик
        [Display(Name = "Компания-исполнитель")] public string ExecutingCompany { get; set; } // компания-исполнитель        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd.MM.yyyy}")]
        [Required] [Display(Name = "Дата начала")] public DateTime StartDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd.MM.yyyy}")]
        [Required] [Display(Name = "Дата окончания")] public DateTime EndDate { get; set; }
        [Display(Name = "Приоритет")] public int Priority { get; set; } // приоритет, 0 - min
        [Display(Name = "Руководителя проекта")] public EmployeeDTO ProjectManager { get; set; } // руководителя проекта
        [Display(Name = "Сотрудники")] public virtual ICollection<EmployeeDTO> Employees { get; set; } // сотрудники
        [Display(Name = "Исполнители")] public virtual ICollection<EmployeeDTO> Executors { get; set; } // исполнители проекта
    }
}

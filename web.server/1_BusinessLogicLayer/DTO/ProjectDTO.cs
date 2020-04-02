using System;
using System.Collections.Generic;
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
        public string Name { get; set; }
        public string CustomerName { get; set; } // компания-заказчик
        public string ExecutingCompany { get; set; } // компания-исполнитель        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; } // приоритет, 0 - min
        public EmployeeDTO ProjectManager { get; set; } // руководителя проекта
        public virtual ICollection<EmployeeDTO> Employees { get; set; } // сотрудники
        public virtual ICollection<EmployeeDTO> Executors { get; set; } // исполнители проекта
    }
}

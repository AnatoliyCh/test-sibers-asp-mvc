using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CustomerName { get; set; } // компания-заказчик
        public string ExecutingCompany { get; set; } // компания-исполнитель        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; } // приоритет, 0 - min
        public EmployeeDTO ProjectManager { get; set; } // руководителя проекта
        public int Employees { get; set; } // сотрудники
        public int Executors { get; set; } // исполнители проекта
    }
}

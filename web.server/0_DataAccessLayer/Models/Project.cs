using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    /// <summary> Проект </summary>
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CustomerName { get; set; } // компания-заказчик
        public string ExecutingCompany { get; set; } // компания-исполнитель        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; } // приоритет, 0 - min
        public int? ProjectManagerId { get; set; } // id руководителя проекта
        public Employee ProjectManager { get; set; } // руководителя проекта
        public virtual ICollection<Employee> Employees { get; set; } // сотрудники
        public virtual ICollection<Employee> Executors { get; set; } // исполнители проекта

        public Project()
        {
            Employees = new List<Employee>();
            Executors = new List<Employee>();
        }
    }
}
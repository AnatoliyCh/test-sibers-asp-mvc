using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CustomerName { get; set; } // компания-заказчик
        public string ExecutingCompany { get; set; } // компания-исполнитель
        public ICollection<Employee> Employees { get; set; } // сотрудники
        public Employee ProjectManager { get; set; } // руководитель проекта
        public ICollection<Employee> Executors { get; set; } // исполнители проекта
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        private int Priority { get; set; }

        public Project()
        {
            Employees = new List<Employee>();
            Executors = new List<Employee>();
        }
    }
}

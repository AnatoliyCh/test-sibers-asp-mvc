using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public int EmployeeInProjects { get; set; } // проекты в которых ОН сотрудник
        public int ExecutorInProjects { get; set; } // проекты в которых ОН исполнитель
    }
}

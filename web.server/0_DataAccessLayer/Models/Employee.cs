using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    /// <summary> Сотрудник </summary>
    public class Employee
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Project> EmployeeInProjects { get; set; } // проекты в которых сотрудник
        public virtual ICollection<Project> ExecutorInProjects { get; set; } // проекты в которых исполнитель

        public Employee()
        {
            EmployeeInProjects = new List<Project>();
            ExecutorInProjects = new List<Project>();
        }
    }
}

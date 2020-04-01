using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace DataAccessLayer.DataBase
{
    public class ProjectDataContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Project>();
            // сотрудники
            entity.HasMany(project => project.Employees).WithMany(employee => employee.EmployeeInProjects).Map(item =>
            {
                item.ToTable("ProjectEmployees"); // промежуточная таблица
                // настройка внешних ключей промежуточной таблицы
                item.MapLeftKey("ProjectId");
                item.MapRightKey("EmployeeId");
            });
            // исполнители
            entity.HasMany(project => project.Executors).WithMany(employee => employee.ExecutorInProjects).Map(item =>
            {
                item.ToTable("ProjectExecutors");
                item.MapLeftKey("ProjectId");
                item.MapRightKey("EmployeeId");
            });
        }
    }
}

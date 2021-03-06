﻿using DataAccessLayer.Models;
using System.Data.Entity;

namespace DataAccessLayer.Context
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
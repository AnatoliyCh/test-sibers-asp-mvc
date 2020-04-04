using DataAccessLayer.Context;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repository.Comparers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
//using System.Data.Entity;
using System.Linq;

namespace DataAccessLayer.Repository
{
    public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {
        public ProjectRepository(ProjectDataContext context) : base(context) { }

        //public override void Update(Project entity)
        //{
        //    //dataContext.Set<Project>().Attach(entity);
        //    //dataContext.Entry(entity).State = EntityState.Modified;
        //    UpdateManytoMany(entity, entity.Id, new string[] { "Employees" });
        //}

        //private void UpdateManytoMany(Project updatedObject, int key, params string[] navigationProperties)
        //{
        //    //using (var dbCtx = new ProjectDataContext())
        //    //{
        //    //    IEqualityComparer<Employee> employeeEqualityComparer = new EmployeeEqualityComparer();
        //    //    // получаем проект со всей коллекцией
        //    //    var existingProject = dbCtx.Projects.Include("Employees").Where(find => find.Name == entity.Name).FirstOrDefault();
        //    //    // удаленные работники
        //    //    var deletedEmployees = existingProject.Employees.Except(entity.Employees).ToList();
        //    //    // добавленные работники
        //    //    //var addedEmployees = Enumerable.Except(entity.Employees, existingProject.Employees, employeeEqualityComparer);
        //    //    var addedEmployees = entity.Employees.Except(existingProject.Employees, employeeEqualityComparer).ToList();
        //    //    // удяляем
        //    //    deletedEmployees.ForEach(employee => existingProject.Employees.Remove(employee));
        //    //    // добавляем
        //    //    foreach (Employee employee in addedEmployees)
        //    //    {
        //    //        if (dbCtx.Entry(employee).State == EntityState.Detached)
        //    //            dbCtx.Employees.Attach(employee);
        //    //        existingProject.Employees.Add(employee);
        //    //    }
        //    //    dbCtx.SaveChanges();
        //    //}

        //    if (updatedObject == null) return;


        //    dataContext.Database.Log = Console.Write;

        //    Project foundEntity = dataContext.Set<Project>().Find(key);
        //    var entry = dataContext.Entry(foundEntity);
        //    entry.CurrentValues.SetValues(updatedObject);
        //    foreach (var prop in navigationProperties)
        //    {
        //        var collection = entry.Collection(prop);
        //        collection.Load();
        //        collection.CurrentValue = typeof(Project).GetProperty(prop).GetValue(updatedObject);
        //    }
        //    dataContext.SaveChanges();
        //    //databaseContext.SaveChanges();
        //    //using (var databaseContext = new ProjectDataContext())
        //    //{
        //    //    databaseContext.Database.Log = Console.Write;

        //    //    Project foundEntity = databaseContext.Set<Project>().Find(key);
        //    //    var entry = databaseContext.Entry(foundEntity);
        //    //    entry.CurrentValues.SetValues(updatedObject);
        //    //    foreach (var prop in navigationProperties)
        //    //    {
        //    //        var collection = entry.Collection(prop);
        //    //        collection.Load();
        //    //        collection.CurrentValue = typeof(Project).GetProperty(prop).GetValue(updatedObject);
        //    //    }
        //    //    //databaseContext.SaveChanges();
        //    //}
        //}
    }
}

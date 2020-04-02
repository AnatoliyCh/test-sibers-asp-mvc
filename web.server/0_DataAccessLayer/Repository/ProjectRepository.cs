using DataAccessLayer.Context;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System.Data.Entity;

namespace DataAccessLayer.Repository
{
    public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {
        public ProjectRepository(ProjectDataContext context) : base(context) { }

        //public override Project Get(int id)
        //{
        //    var find = base.Get(id);
        //    dataContext.Projects.Find(id).;
        //    return null;
        //}
    }
}

using DataAccessLayer.Models;
using System.Collections.Generic;

namespace DataAccessLayer.Repository.Comparers
{
    public class ProjectEqualityComparer : IEqualityComparer<Project>
    {
        public bool Equals(Project x, Project y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Project obj)
        {
            return obj.GetHashCode();
        }
    }
}
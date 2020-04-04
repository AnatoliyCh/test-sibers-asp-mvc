﻿using DataAccessLayer.Models;
using System.Collections.Generic;

namespace BusinessLogicLayer.Infrastructure.Comparers
{
    class EmployeeEqualityComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            return x.Id == y.Id;
        }
        public int GetHashCode(Employee obj)
        {
            return obj.GetHashCode();
        }
    }
}
﻿using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccessLayer.Repository
{
    public abstract class RepositoryBase<T> where T : class
    {
        protected ProjectDataContext dataContext;
        private readonly IDbSet<T> dbSet;

        protected RepositoryBase(ProjectDataContext context)
        {
            dataContext = context;
            dbSet = dataContext.Set<T>();
        }

        public virtual T Get(int id)
        {
            return dbSet.Find(id);
        }
        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }
        public virtual void Create(T entity) => dbSet.Add(entity);
        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(T entity) => dbSet.Remove(entity);
        public virtual void Delete(int id)
        {
            T entity = dbSet.Find(id);
            if (entity != null) dbSet.Remove(entity);
        }
        public virtual IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return dbSet.Where(predicate).ToList();
        }
    }
}
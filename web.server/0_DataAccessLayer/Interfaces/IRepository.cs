using System;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> GetAll();               
        void Create(T item);
        /// <summary> обновление только сущности </summary>
        void Update(T item);
        /// <summary> обновление сущности и всех свойств многие-ко-многим </summary>
        /// <param name="navigationProperties">список свойств</param>
        void Update(T entity, int id, string[] navigationProperties = null);
        void Delete(T entity);
        void Delete(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
    }
}

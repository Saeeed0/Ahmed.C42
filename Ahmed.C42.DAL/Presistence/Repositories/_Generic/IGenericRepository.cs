using Ahmed.C42.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ahmed.C42.DAL.Presistence.Repositories._Generic
{
    public interface IGenericRepository<T> where T : ModelBase
    {
        T Get(int Id);

        //List<T> GetAll();
        IEnumerable<T> GetAll(bool withAsNoTracking = true);

        IQueryable<T> GetAllAsIQueryable();
        IEnumerable<T> GetAllAsIEnumerable();

        /*int*/ void Add(T entity);

        /*int*/ void Update(T entity);

        /*int*/ void Delete(T entity);
    }
}

using Ahmed.C42.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ahmed.C42.DAL.Presistence.Repositories._Generic
{
    public interface IGenericRepository<T> where T : ModelBase
    {
        Task<T> GetAsync(int Id);

        //List<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync(bool withAsNoTracking = true);

        IQueryable<T> GetAllAsIQueryable();
        IEnumerable<T> GetAllAsIEnumerable();

        /*int*/ void Add(T entity);

        /*int*/ void Update(T entity);

        /*int*/ void Delete(T entity);
    }
}

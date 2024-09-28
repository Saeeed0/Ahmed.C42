using Ahmed.C42.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmed.C42.DAL.Presistence.Repositories._Generic
{
    public interface IGenericRepository<T> where T : ModelBase
    {
        T Get(int Id);

        //List<T> GetAll();
        IEnumerable<T> GetAll(bool withAsNoTracking = true);

        IQueryable<T> GetAllAsIQueryable();
        IEnumerable<T> GetAllAsIEnumerable();

        int Add(T entity);

        int Update(T entity);

        int Delete(T entity);
    }
}

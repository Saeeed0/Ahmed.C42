using Ahmed.C42.DAL.Entities;
using Ahmed.C42.DAL.Presistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmed.C42.DAL.Presistence.Repositories._Generic
{
    public class GenericRepository<T> where T : ModelBase
    {
        private protected readonly ApplicationDbContext _dbContext;//Null
        public GenericRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        //public IEnumerable<T> GetAll()
        //    => _dbContext.Set<T>().AsNoTracking().ToList();//AsNoTracking(): Use this when you’re just reading data and don’t plan to modify or save it, making your queries faster.

        public T Get(int Id)
        {
            return _dbContext.Find<T>(Id);
            ///find first in Local if don't exist find in DB , search using only the primary key of the entity
            ///return _dbContext.Ts.Find(Id);//find first in Local if don't exist find in DB
            ///var T = _dbContext.Ts.Local.FirstOrDefault(D => D.Id == Id);
            ///if (T == null) T = _dbContext.Ts.FirstOrDefault(D => D.Id == Id);
            ///return T;
        }

        public IEnumerable<T> GetAll(bool withAsNoTracking = true)
        {
            if (withAsNoTracking)
                return _dbContext.Set<T>().Where(X => !X.IsDeleted).AsNoTracking().ToList(); 
            return _dbContext.Set<T>().Where(X => !X.IsDeleted).ToList();

            //if (withAsNoTracking)
            //    return _dbContext.Set<T>().AsNoTracking().ToList();
            //return _dbContext.Set<T>().ToList();

        }

        public IQueryable<T> GetAllAsIQueryable()//work with immidiate operator
        {
            return _dbContext.Set<T>().Where(X => !X.IsDeleted).AsNoTracking();//Set<T>() is a DbSet and the DbSet implements the IQueryable

        }

        public int Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return _dbContext.SaveChanges();
        }
        public int Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return _dbContext.SaveChanges();
        }
        public int Delete(T entity)
        {
            //_dbContext.Set<T>().Remove(entity);//Hard Delete
            entity.IsDeleted = true;//Soft Delete
            _dbContext.Set<T>().Update(entity);
            return _dbContext.SaveChanges();
        }
    }
}

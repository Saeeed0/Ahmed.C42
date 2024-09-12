using Ahmed.C42.BLL.Interfaces;
using Ahmed.C42.DAL.Data;
using Ahmed.C42.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmed.C42.BLL.Repositories
{
    internal class DepartmentRepository : IDepartmentRepository
    {
        readonly ApplicationDbContext _dbContext;//Null
        //public DepartmentRepository()//without using DI
        //{
        //    _dbContext = new ApplicationDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>());
        //}
        public DepartmentRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public int Add(Department entity)
        {
            _dbContext.Departments.Add(entity);
            return _dbContext.SaveChanges();
        }
        public int Update(Department entity)
        {
            _dbContext.Departments.Update(entity);
            return _dbContext.SaveChanges();
        }
        public int Delete(Department entity)
        {
            _dbContext.Departments.Remove(entity);
            return _dbContext.SaveChanges();
        }

        public Department Get(int Id)
        {
            return _dbContext.Find<Department>(Id);//find first in Local if don't exist find in DB
            //return _dbContext.Departments.Find(Id);//find first in Local if don't exist find in DB
            //var department = _dbContext.Departments.Local.Where(D => D.Id == Id).FirstOrDefault();
            //if (department == null) department = _dbContext.Departments.Where(D => D.Id == Id).FirstOrDefault();
            //return department;
        }

        public IEnumerable<Department> GetAll()
            => _dbContext.Departments.AsNoTracking().ToList();



    }
}

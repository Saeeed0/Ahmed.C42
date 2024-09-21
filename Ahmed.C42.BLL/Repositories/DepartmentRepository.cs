using Ahmed.C42.BLL.Interfaces;
using Ahmed.C42.DAL.Models.Department;
using Ahmed.C42.DAL.Presistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmed.C42.BLL.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
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
        //public IEnumerable<Department> GetAll()
        //    => _dbContext.Departments.AsNoTracking().ToList();//AsNoTracking(): Use this when you’re just reading data and don’t plan to modify or save it, making your queries faster.

        public IEnumerable<Department> GetAll(bool withAsNoTracking = true)
        {
            if (withAsNoTracking)
                return _dbContext.Departments.AsNoTracking().ToList();
            return _dbContext.Departments.ToList();
        }
        public Department GetById(int Id)
        {
            return _dbContext.Find<Department>(Id);
            ///find first in Local if don't exist find in DB , search using only the primary key of the entity
            ///return _dbContext.Departments.Find(Id);//find first in Local if don't exist find in DB
            ///var department = _dbContext.Departments.Local.FirstOrDefault(D => D.Id == Id);
            ///if (department == null) department = _dbContext.Departments.FirstOrDefault(D => D.Id == Id);
            ///return department;
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

        

        
    }
}

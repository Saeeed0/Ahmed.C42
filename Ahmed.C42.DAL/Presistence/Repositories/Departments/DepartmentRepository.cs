﻿using Ahmed.C42.DAL.Entities.Department;
using Ahmed.C42.DAL.Presistence.Data;
using Ahmed.C42.DAL.Presistence.Repositories._Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmed.C42.DAL.Presistence.Repositories.Departments
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        //public DepartmentRepository()//without using DI
        //{
        //    _dbContext = new ApplicationDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>());
        //}

        public DepartmentRepository(ApplicationDbContext applicationDbContext)//Ask CLR for Object from ApplicationDbContext Implicitly
            : base(applicationDbContext)
        {
            //_dbContext = applicationDbContext; //you will inhiret from GenericRepository
        }



    }
}

using Ahmed.C42.DAL.Entities.Departments;
using Ahmed.C42.DAL.Presistence.Data;
using Ahmed.C42.DAL.Presistence.Repositories._Generic; 

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

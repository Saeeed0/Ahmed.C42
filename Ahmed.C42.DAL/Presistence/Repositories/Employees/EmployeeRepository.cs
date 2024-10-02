using Ahmed.C42.DAL.Entities.Employees;
using Ahmed.C42.DAL.Presistence.Data;
using Ahmed.C42.DAL.Presistence.Repositories._Generic; 

namespace Ahmed.C42.DAL.Presistence.Repositories.Employees
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        //public EmployeeRepository()//without using DI
        //{
        //    _dbContext = new ApplicationDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>());
        //}

        public EmployeeRepository(ApplicationDbContext applicationDbContext)//Ask CLR for Object from ApplicationDbContext Implicitly
            : base(applicationDbContext)
        {
            //_dbContext = applicationDbContext; //you will inhiret from GenericRepository
        }

        
    }
}

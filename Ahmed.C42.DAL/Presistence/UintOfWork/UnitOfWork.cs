using Ahmed.C42.DAL.Presistence.Data;
using Ahmed.C42.DAL.Presistence.Repositories.Departments;
using Ahmed.C42.DAL.Presistence.Repositories.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmed.C42.DAL.Presistence.UintOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public IEmployeeRepository EmployeeRepository => new EmployeeRepository(_dbContext);

        public IDepartmentRepository DepartmentRepository => new DepartmentRepository(_dbContext);

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync();// Save all changes in one transaction
        }

        public async ValueTask DisposeAsync()
        {
             await _dbContext.DisposeAsync();
        }
    }
}

using Ahmed.C42.DAL.Presistence.Repositories.Departments;
using Ahmed.C42.DAL.Presistence.Repositories.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmed.C42.DAL.Presistence.UintOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        public IEmployeeRepository EmployeeRepository { get; /*set;*/ }
        public IDepartmentRepository DepartmentRepository { get; /*set;*/ }

        public Task<int> CompleteAsync();
    }
}

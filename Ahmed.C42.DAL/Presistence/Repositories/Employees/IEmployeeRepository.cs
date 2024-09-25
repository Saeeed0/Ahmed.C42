using Ahmed.C42.DAL.Entities.Employee;
using Ahmed.C42.DAL.Presistence.Repositories._Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmed.C42.DAL.Presistence.Repositories.Employees
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        
    }
}

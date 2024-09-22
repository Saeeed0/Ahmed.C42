using Ahmed.C42.DAL.Entities.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmed.C42.DAL.Presistence.Repositories.Departments
{
    public interface IDepartmentRepository
    {
        Department Get(int Id);

        //List<Department> GetAll();
        IEnumerable<Department> GetAll(bool withAsNoTracking = true);

        IQueryable<Department> GetAllAsIQueryable();

        int Add(Department entity);

        int Update(Department entity);

        int Delete(Department entity);

    }
}

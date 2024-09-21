using Ahmed.C42.DAL.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmed.C42.BLL.Interfaces
{
    public interface IDepartmentRepository
    {
        //List<Department> GetAll();
        IEnumerable<Department> GetAll();
        Department Get(int Id);
        int Add(Department entity);
        int Update(Department entity);
        int Delete(Department entity);
        
    }
}

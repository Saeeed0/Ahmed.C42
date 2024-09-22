using Ahmed.C42.BLL.CustomModel.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmed.C42.BLL.Services.Departments
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentToReturnDto> GetAllDepartmnets();
        DepartmentDetailsToReturnDto GetDepartmentById(int id);
        int CreateDepartment(CreatedDepartmentDto department);
        int UpdateDepartment(UpdatedDepartmentDto department);

        bool DeleteDepartment(int id);
    }
}

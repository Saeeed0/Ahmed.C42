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
        Task<IEnumerable<DepartmentDto>> GetAllDepartmnetsAsync();
        Task<DepartmentDetailsDto> GetDepartmentByIdAsync(int id);
        Task<int> CreateDepartmentAsync(CreatedDepartmentDto department);
        Task<int> UpdateDepartmentAsync(UpdatedDepartmentDto department);

        Task<bool> DeleteDepartmentAsync(int id);
    }
}

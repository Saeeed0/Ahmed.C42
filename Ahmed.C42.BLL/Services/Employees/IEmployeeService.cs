using Ahmed.C42.BLL.CustomModel.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmed.C42.BLL.Services.Employees
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(string search);

        Task<EmployeeDetailsDto> GetEmployeeByIdAsync(int id);

        Task<int> CreateEmployeeAsync(CreatedEmployeeDto employeeDto);

        Task<int> UpdateEmployeeAsync(UpdatedEmployeeDto employeeDto);

        Task<bool> DeleteEmployeeAsync(int id);
    }
}

using Ahmed.C42.DAL.Entities.Employees.Commen.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmed.C42.BLL.CustomModel.Employees
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int? Age { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        public Gender Gender { get; set; } 

        public EmployeeType EmployeeType { get; set; }

        //[Display(Name = "Department")]
        public string? Department { get; set; }

        public string? Image { get; set; }
    }
}

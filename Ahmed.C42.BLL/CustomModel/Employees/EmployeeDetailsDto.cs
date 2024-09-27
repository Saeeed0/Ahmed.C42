using Ahmed.C42.DAL.Entities.Employee.Commen.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmed.C42.BLL.CustomModel.Employees
{
    public class EmployeeDetailsDto
    {
        public int Id { get; set; }

        #region Administration Section
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; } 
        #endregion

        public string Name { get; set; } = null!;

        public int? Age { get; set; }

        public string? Address { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Display(Name = "Phone Number")]
        [Phone]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Hirring Date")]
        //[DataType(DataType.DateTime)]
        public DateTime HirringDate { get; set; }

        public Gender Gender { get; set; } 

        public EmployeeType EmployeeType { get; set; } 
    }
}

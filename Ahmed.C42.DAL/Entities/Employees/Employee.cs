using Ahmed.C42.DAL.Entities.Departments;
using Ahmed.C42.DAL.Entities.Employees.Commen.Enum;
using System;
namespace Ahmed.C42.DAL.Entities.Employees
{

    public class Employee : ModelBase
    {
        public string Name { get; set; } = null!;

        public int? Age { get; set; }

        public string? Address { get; set; }

        public decimal Salary { get; set; }

        public bool IsActive { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime HirringDate { get; set; }

        public Gender Gender { get; set; }

        public EmployeeType EmployeeType { get; set; }


        // Foreign Key
        public int? DepartmentId { get; set; }

        // Navigation property (singular, one employee works in one department)
        public virtual Department? Department { get; set; }

        public string? Image { get; set; }

        #region using Data Annotation
        //    [Required]
        //    [MaxLength(50, ErrorMessage = "Max Length of Name is 50 Chars")]
        //    [MinLength(5, ErrorMessage = "Min Length of Name is 5 Chars")]
        //    public string Name { get; set; } = null!;

        //    [Range(22, 30)]
        //    public int Age { get; set; }

        //    [RegularExpression(@"^[0-9]{1,3}-[a-zA-Z]{5-10}-[a-zA-Z]{4-10}-[a-zA-Z]{5-10}",
        //        ErrorMessage = "Address Must be Like 123-Street-City-Country")]
        //    public string Address { get; set; }

        //    [DataType(DataType.Currency)]
        //    public decimal Salary { get; set; }

        //    [Display(Name ="Is Active")]
        //    public bool IsActive { get; set; }

        //    [EmailAddress]
        //    public string? Email { get; set; }

        //    [Display(Name = "Phone Number")]
        //    [Phone]
        //    public string? PhoneNumber { get; set; }

        //    [Display(Name = "Hirring Date")]
        //    //[DataType(DataType.DateTime)]
        //    public DateTime HirringDate { get; set; }

        //    public Gender Gender { get; set; }

        //    public EmployeeType EmployeeType { get; set; } 
        #endregion

    }
   
}



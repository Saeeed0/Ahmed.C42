﻿using Ahmed.C42.DAL.Entities.Employee.Commen.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmed.C42.BLL.CustomModel.Employees
{
    public class UpdatedEmployeeDto
    {
        public int Id { get; set; }
        //    [Required]
        [MaxLength(50, ErrorMessage = "Max Length of Name is 50 Chars")]
        [MinLength(5, ErrorMessage = "Min Length of Name is 5 Chars")]
        public string Name { get; set; } = null!;

        [Range(22, 30)]
        public int? Age { get; set; }

        [RegularExpression(@"^[0-9]{1,3}-[a-zA-Z]{5-10}-[a-zA-Z]{4-10}-[a-zA-Z]{5-10}",
            ErrorMessage = "Address Must be Like 123-Street-City-Country")]
        public string? Address { get; set; }

        public decimal Salary { get; set; }

        public bool IsActive { get; set; }

        [EmailAddress]
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

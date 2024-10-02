using Ahmed.C42.DAL.Entities.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ahmed.C42.DAL.Entities.Departments //foreach Module (Models.Department) usualy has more than model (Department)
{
    //Model Represent a Department Table
    public class Department : ModelBase
    {
        public string Name { get; set; } = null!;
        [Required/*(ErrorMessage ="Code is Required ya Hamada!!")*/]//ErrorMessage Should inside View Modle
        public string Code { get; set; } = null!;
        //[Required]///We prefer select Required or any DataAnotation inside fluent API
        public string? Description { get; set; } 

        public DateTime CreationDateTime { get; set; } //(ex: the Date that the Department Salse Created in the Company)

        // Navigation property for one-to-many relationship
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}

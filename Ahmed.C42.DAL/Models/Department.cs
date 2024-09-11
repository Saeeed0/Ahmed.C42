using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmed.C42.DAL.Models
{
    //Model Represent a Department Table
    public class Department
    {
        public int Id { get; set; }
        [Required/*(ErrorMessage ="Code is Required ya Hamada!!")*/]//ErrorMessage Should inside View Modle
        public string Code { get; set; }
        //[Required]///We prefer select Required or any DataAnotation inside fluent API
        public string Name { get; set; }
        public DateTime DateOfCreation { get; set; }
    }
}

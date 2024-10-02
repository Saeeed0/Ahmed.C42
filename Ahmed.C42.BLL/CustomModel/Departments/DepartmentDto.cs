using Ahmed.C42.DAL.Entities.Departments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmed.C42.BLL.CustomModel.Departments
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;

        [Display(Name = "Date Of Creation")]
        public DateTime CreationDateTime { get; set; }

        //public static explicit operator DepartmentToReturnDto(Department department)
        //{
        //    return new DepartmentToReturnDto()
        //    {
        //        Id = department.Id,
        //        Code = department.Code,
        //        Name = department.Name,
        //        Description = department.Description,
        //        CreationDateTime = department.CreationDateTime,
        //    };
        //}

    }
}

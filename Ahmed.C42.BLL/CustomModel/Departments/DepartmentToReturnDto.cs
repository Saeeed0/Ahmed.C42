using Ahmed.C42.DAL.Entities.Department;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmed.C42.BLL.CustomModel.Departments
{
    public class DepartmentToReturnDto
    {
        public int Id { get; set; }
        //public int CreatedBy { get; set; }
        //public DateTime CreatedOn { get; set; } 
        //public int LastModifiedBy { get; set; }
        //public DateTime LastModifiedOn { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreationDateTime { get; set; }

        public static explicit operator DepartmentToReturnDto(Department department)
        {
            return new DepartmentToReturnDto()
            {
                Id = department.Id,
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                CreationDateTime = department.CreationDateTime,
            };
        }

    }
}

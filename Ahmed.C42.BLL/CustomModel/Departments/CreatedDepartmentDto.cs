using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmed.C42.BLL.CustomModel.Departments
{
    public class CreatedDepartmentDto
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        [Display(Name = "Date Time of Creation")]
        public DateTime CreationDateTime { get; set; }
    }
}

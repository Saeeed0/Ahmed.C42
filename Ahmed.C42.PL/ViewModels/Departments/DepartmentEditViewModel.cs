using System;

namespace Ahmed.C42.PL.ViewModels.Departments
{
    public class DepartmentEditViewModel
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}

using Ahmed.C42.BLL.Interfaces;
using Ahmed.C42.BLL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Ahmed.C42.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepo;
        //public DepartmentController()//without using DI
        //{
        //    _departmentRepo = new DepartmentRepository(new DAL.Data.ApplicationDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<DAL.Data.ApplicationDbContext>()));
        //}
        public DepartmentController(IDepartmentRepository departmentRepository) //with using DI , Ask CLR to Create an Object from Class Implementing IDepartmentRepository
        {
            _departmentRepo = departmentRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

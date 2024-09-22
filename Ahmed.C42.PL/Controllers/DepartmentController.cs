﻿using Ahmed.C42.DAL.Entities.Department;
using Ahmed.C42.DAL.Presistence.Repositories.Departments;
using Microsoft.AspNetCore.Mvc;

namespace Ahmed.C42.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentsRepo;
        //public DepartmentController()//without using DI
        //{
        //    _departmentRepo = new DepartmentRepository(new DAL.Data.ApplicationDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<DAL.Data.ApplicationDbContext>()));
        //}
        public DepartmentController(IDepartmentRepository departmentRepository) //with using DI , Ask CLR to Create an Object from Class Implementing IDepartmentRepository
        {
            _departmentsRepo = departmentRepository;
        }
        public IActionResult Index()
        {
            var departments=_departmentsRepo.GetAll();
            return View(departments);
        }
        [HttpGet] //Get the Form that you can fill in
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost] //Submit the Form
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)//Server-Side Validation
            {
                var count = _departmentsRepo.Add(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var department = _departmentsRepo.Get(id.Value);

            if (department is null)
                return NotFound();

            return View(department);
        }
    }
}

﻿using Ahmed.C42.BLL.CustomModel.Departments;
using Ahmed.C42.BLL.Services.Departments;
using Ahmed.C42.DAL.Entities.Department;
using Ahmed.C42.PL.ViewModels.Departments;
using Microsoft.AspNetCore.Hosting;

//using Ahmed.C42.DAL.Presistence.Repositories.Departments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace Ahmed.C42.PL.Controllers
{   //Inheritance: DepartmentController is a Controller
    //Composition: DepartmentController has IDepartmentService  (if IDepartmentService? will agrigation)
    public class DepartmentController : Controller
    {
        #region Serviecs

        #region without using IDepartmentService
        //private readonly IDepartmentRepository _departmentsRepo;
        ////public DepartmentController()//without using DI
        ////{
        ////    _departmentRepo = new DepartmentRepository(new DAL.Data.ApplicationDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<DAL.Data.ApplicationDbContext>()));
        ////}
        //public DepartmentController(IDepartmentRepository departmentRepository) //with using DI , Ask CLR to Create an Object from Class Implementing IDepartmentRepository
        //{
        //    _departmentsRepo = departmentRepository;
        //}
        //public IActionResult Index()
        //{
        //    var departments=_departmentsRepo.GetAll();
        //    return View(departments);
        //}
        //[HttpGet] //Get the Form that you can fill in
        //public IActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost] //Submit the Form
        //public IActionResult Create(Department department)
        //{
        //    if (ModelState.IsValid)//Server-Side Validation
        //    {
        //        var count = _departmentsRepo.Add(department);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(department);
        //}
        //[HttpGet]
        //public IActionResult Details(int? id)
        //{
        //    if (!id.HasValue)
        //        return BadRequest();
        //    var department = _departmentsRepo.Get(id.Value);

        //    if (department is null)
        //        return NotFound();

        //    return View(department);
        //} 
        #endregion

        private readonly IDepartmentService _departmentService;
        private readonly ILogger<DepartmentController> _logger;
        private readonly IWebHostEnvironment _environment;

        public DepartmentController(
            IDepartmentService departmentService,
            ILogger<DepartmentController> logger,
            IWebHostEnvironment environment)//we don't prefer to use ILogger
        {
            _departmentService = departmentService;
            _logger = logger;
            _environment = environment;
        } 

        #endregion

        #region Index

        [HttpGet]
        public IActionResult Index()
        {
            var department = _departmentService.GetAllDepartmnets();
            return View(department);
        }

        #endregion

        #region Details

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var department = _departmentService.GetDepartmentById(id.Value);

            if (department is null)
                return NotFound();

            return View(department);
        }

        #endregion

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreatedDepartmentDto departmentDto)
        {
            if (!ModelState.IsValid)
                return View(departmentDto);

            string message = string.Empty;
            try
            {
                var result = _departmentService.CreateDepartment(departmentDto);

                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    message = "Department is not Created";
                    ModelState.AddModelError(string.Empty, message);
                    return View(departmentDto);
                }
            }
            catch (Exception ex)
            {
                //Log Error
                _logger.LogError(ex, ex.Message);//the Logging will be in Console(kestrel)

                //Set Message
                message = _environment.IsDevelopment() ? ex.Message : "an error occured during create the department :(";

            }

            ModelState.AddModelError(string.Empty, message);
            return View(departmentDto);
        }

        #endregion

        #region Edit

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var department = _departmentService.GetDepartmentById(id.Value);

            if (department is null)
                return NotFound();

            return View(new DepartmentViewModel
            {
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                CreationDateTime = department.CreationDateTime
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, DepartmentViewModel departmentEditVM)
        {
            if (!ModelState.IsValid)
                return View(departmentEditVM);

            var message = string.Empty;

            try
            {
                var departmentToUpdate = new UpdatedDepartmentDto()
                {
                    Id = id,
                    Code = departmentEditVM.Code,
                    Name = departmentEditVM.Name,
                    Description = departmentEditVM.Description,
                    CreationDateTime = departmentEditVM.CreationDateTime
                };

                var updated = _departmentService.UpdateDepartment(departmentToUpdate) > 0;

                if (updated)
                    return RedirectToAction(nameof(Index));

                message = "an error occured during updating the department :(";

                return View(departmentEditVM);
            }
            catch (Exception ex)
            {
                //Log Error
                _logger.LogError(ex, ex.Message);//the Logging will be in Console(kestrel)

                //Set Message
                message = _environment.IsDevelopment() ? ex.Message : "an error occured during updating the department :(";

            }

            ModelState.AddModelError(string.Empty, message);
            return View(departmentEditVM);
        }

        #endregion

        #region Delete

        //[HttpGet]
        //public IActionResult Delete(int? id)
        //{
        //    if (!id.HasValue)
        //        return BadRequest();

        //    var department = _departmentService.GetDepartmentById(id.Value);

        //    if (department is null)
        //        return NotFound();

        //    return View(department);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {

            var message = string.Empty;

            try
            {
                var deleted = _departmentService.DeleteDepartment(id);
                if (deleted)
                    return RedirectToAction(nameof(Index));

                message = "an error occured during Deleting the department :(";

            }
            catch (Exception ex)
            {
                //Log Error
                _logger.LogError(ex, ex.Message);//the Logging will be in Console(kestrel)

                //Set Message
                message = _environment.IsDevelopment() ? ex.Message : "an error occured during Deleting the department :(";
            }

            //ModelState.AddModelError(string.Empty, message);
            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
    //scaffolding process => 1.install package 2. update dependance information 3. build the project 4. generate the view
}

using Ahmed.C42.BLL.CustomModel.Employees;
using Ahmed.C42.BLL.Services.Departments;
using Ahmed.C42.BLL.Services.Employees;
using Ahmed.C42.DAL.Entities.Employees.Commen.Enum;
using Ahmed.C42.PL.ViewModels.Employees;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace Ahmed.C42.PL.Controllers
{
    public class EmployeeController : Controller
    {
        #region Servieces

        private readonly IEmployeeService _employeeService;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(
            IEmployeeService employeeService,
            IWebHostEnvironment environment,
            ILogger<EmployeeController> logger
            /*,IDepartmentService departmentService*/)
        {
            _employeeService = employeeService;
            _environment = environment;
            _logger = logger;
        } 

        #endregion

        #region Index

        [HttpGet]
        public IActionResult Index()
        {
            var employee = _employeeService.GetAllEmployees();
            return View(employee);
        }

        #endregion

        #region Details

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id is null)
                return BadRequest();

            var emloyee = _employeeService.GetEmployeeById(id.Value);

            if (emloyee is null)
                return NotFound();

            return View(emloyee);

        }

        #endregion

        #region Create

        [HttpGet]
        public IActionResult Create(/*[FromServices] IDepartmentService departmentService*/)
        {
            //ViewData["Departments"] = departmentService.GetAllDepartmnets();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreatedEmployeeDto employeeDto )
        {
            if (!ModelState.IsValid)
                return View(employeeDto);

            var message = string.Empty;

            try
            {
                var result = _employeeService.CreateEmployee(employeeDto);
                if (result > 0)
                    return RedirectToAction(nameof(Index));

                message = "Employee is Not Created";
                ModelState.AddModelError(string.Empty, message);
                return View(employeeDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                message = _environment.IsDevelopment() ? ex.Message : "An Error Occur During Creating the Employee";
            }

            ModelState.AddModelError(string.Empty, message);
            return View(employeeDto);
        }

        #endregion

        #region Edit

        [HttpGet]
        public IActionResult Edit(int? id, [FromServices] IDepartmentService departmentService)
        {
            if (id is null)
                return BadRequest();

            var employee = _employeeService.GetEmployeeById(id.Value);

            if (employee == null)
                return NotFound();

            ViewData["Departments"] = departmentService.GetAllDepartmnets();

            return View(new UpdatedEmployeeDto()
            {
                Name = employee.Name,
                Age = employee.Age,
                Salary = employee.Salary,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Address = employee.Address,
                DepartmentId = employee.DepartmentId,
                Gender = employee.Gender/*.ToString()*/,
                EmployeeType = employee.EmployeeType/*.ToString()*/,
                HirringDate = employee.HirringDate,
                IsActive = employee.IsActive
                
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, EmployeeEditViewModel employeeEditVM)
        {
            if (!ModelState.IsValid)
                return View(employeeEditVM);

            var message = string.Empty;

            try
            {
                var employeeToUpdate = new UpdatedEmployeeDto()
                {
                    Id = id,
                    Name = employeeEditVM.Name,
                    Age = employeeEditVM.Age,
                    Salary = employeeEditVM.Salary,
                    Email = employeeEditVM.Email,
                    PhoneNumber= employeeEditVM.PhoneNumber,
                    Address = employeeEditVM.Address,
                    IsActive= employeeEditVM.IsActive,
                    HirringDate = employeeEditVM.HirringDate,
                    DepartmentId = employeeEditVM.DepartmentId,
                    Gender = Enum.Parse<Gender>(employeeEditVM.Gender),
                    EmployeeType = Enum.Parse<EmployeeType>(employeeEditVM.EmployeeType)

                };

                var updated = _employeeService.UpdateEmployee(employeeToUpdate);

                if (updated > 0)
                    return RedirectToAction(nameof(Index));

                message = "an Error Occur During Updating the Employee :(";

                return View(employeeEditVM);

            }
            catch (Exception ex)
            {
                //Log Error
                _logger.LogError(ex, ex.Message);//the Logging will be in Console(kestrel)

                //Set Message
                message = _environment.IsDevelopment() ? ex.Message : "an Error Occur During Updating the Employee :(";
            }

            ModelState.AddModelError(string.Empty, message);
            return View(employeeEditVM);
        }

        #endregion

        #region Delete

        //[HttpGet]
        //public IActionResult Delete(int? id)
        //{
        //    if (id is null)
        //        return BadRequest();

        //    var employee = _employeeService.GetEmployeeById(id.Value);

        //    if (employee is null)
        //        return NotFound();

        //    return View(employee);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var message = string.Empty;

            try
            {
                var deleted = _employeeService.DeleteEmployee(id);

                if (deleted)
                    return RedirectToAction(nameof(Index));

                message = "an Error Occured During Deleting the Employee :(";
            }
            catch (Exception ex)
            {
                //log error
                _logger.LogError(ex, ex.Message);

                //set message
                message = _environment.IsDevelopment() ? ex.Message : message = "an Error Occured During Deleting the Employee :(";
            }

            return RedirectToAction(nameof(Index));
        } 

        #endregion


    }
}


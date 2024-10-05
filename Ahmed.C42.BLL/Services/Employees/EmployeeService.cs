using Ahmed.C42.BLL.CustomModel.Employees;
using Ahmed.C42.DAL.Entities.Employees;
using Ahmed.C42.DAL.Presistence.Repositories.Employees;
using Ahmed.C42.DAL.Presistence.UintOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmed.C42.BLL.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)//Ask CLR for creating Object from class implementing IUnitOfWork
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<EmployeeDto> GetEmployees(string search)
        {
            var _employeeRepository = _unitOfWork.EmployeeRepository;
            return _employeeRepository.GetAllAsIQueryable()
                .Where(E => !E.IsDeleted && (string.IsNullOrEmpty(search) || E.Name.ToLower().Contains(search.ToLower())))
                .Include(E => E.Department)//Egar Loading
                .Select(employee => new EmployeeDto
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Age = employee.Age,
                    IsActive = employee.IsActive,
                    Salary = employee.Salary,
                    Email = employee.Email,
                    Department = employee.Department.Name,//Lazy Loading
                    Gender = employee.Gender,
                    EmployeeType = employee.EmployeeType
                    //Gender = employee.Gender.ToString(),
                    //EmployeeType = employee.EmployeeType.ToString()

                }).ToList();

        }

        public EmployeeDetailsDto GetEmployeeById(int id)
        {
            var _employeeRepository = _unitOfWork.EmployeeRepository;

            var employee = _employeeRepository.Get(id);
            if (employee is not null)
                return new EmployeeDetailsDto()
                {

                    Id = employee.Id,
                    Name = employee.Name,
                    Age = employee.Age,
                    Address = employee.Address,
                    IsActive = employee.IsActive,
                    Salary = employee.Salary,
                    Email = employee.Email,
                    PhoneNumber = employee.PhoneNumber,
                    HirringDate = employee.HirringDate,
                    Gender = employee.Gender,
                    EmployeeType = employee.EmployeeType,
                    Department = employee.Department.Name,
                    DepartmentId = employee.DepartmentId,

                };
            return null;
        }

        public int CreateEmployee(CreatedEmployeeDto employeeDto)
        {
            var employee = new Employee()
            {
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                Address = employeeDto.Address,
                IsActive = employeeDto.IsActive,
                Salary = employeeDto.Salary,
                Email = employeeDto.Email,
                PhoneNumber = employeeDto.PhoneNumber,
                HirringDate = employeeDto.HirringDate,
                DepartmentId = employeeDto.DepartmentID,
                Gender = employeeDto.Gender,
                EmployeeType = employeeDto.EmployeeType,
                //CreatedOn = DateTime.UtcNow,//.HasDefaultValueSql("GETDATE()") in employeeconfiguration
                CreatedBy = 1,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.UtcNow

            };

            _unitOfWork.EmployeeRepository.Add(employee);
            return _unitOfWork.Complete();
        }

        public int UpdateEmployee(UpdatedEmployeeDto employeeDto)
        {
            var employee = new Employee()
            {
                Id = employeeDto.Id,
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                Address = employeeDto.Address,
                IsActive = employeeDto.IsActive,
                Salary = employeeDto.Salary,
                Email = employeeDto.Email,
                PhoneNumber = employeeDto.PhoneNumber,
                HirringDate = employeeDto.HirringDate,
                DepartmentId = employeeDto.DepartmentId,
                Gender = employeeDto.Gender,
                EmployeeType = employeeDto.EmployeeType,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.UtcNow

            };
            _unitOfWork.EmployeeRepository.Update(employee);
            return _unitOfWork.Complete();
        }

        public bool DeleteEmployee(int id)
        {
            var _employeeReository = _unitOfWork.EmployeeRepository;

            var employee = _employeeReository.Get(id);

            if (employee is not null)
                _employeeReository.Delete(employee);

            return _unitOfWork.Complete()>0;
        }



    }


    #region Before Using UintOfWork
    //public class EmployeeService : IEmployeeService
    //{
    //    private readonly IEmployeeRepository _employeeRepository;

    //    public EmployeeService(IEmployeeRepository employeeRepository)//Ask CLR for creating Object from class implementing IEmployeeRepository
    //    {
    //        _employeeRepository = employeeRepository;
    //    }

    //    public IEnumerable<EmployeeDto> GetEmployees(string search)
    //    {
    //        return _employeeRepository.GetAllAsIQueryable()
    //            .Where(E => !E.IsDeleted && (string.IsNullOrEmpty(search) || E.Name.ToLower().Contains(search.ToLower())))
    //            .Include(E => E.Department)//Egar Loading
    //            .Select(employee => new EmployeeDto
    //            {
    //                Id = employee.Id,
    //                Name = employee.Name,
    //                Age = employee.Age,
    //                IsActive = employee.IsActive,
    //                Salary = employee.Salary,
    //                Email = employee.Email,
    //                Department = employee.Department.Name,//Lazy Loading
    //                Gender = employee.Gender,
    //                EmployeeType = employee.EmployeeType
    //                //Gender = employee.Gender.ToString(),
    //                //EmployeeType = employee.EmployeeType.ToString()

    //            }).ToList();

    //    }

    //    public EmployeeDetailsDto GetEmployeeById(int id)
    //    {
    //        var employee = _employeeRepository.Get(id);
    //        if (employee is not null)
    //            return new EmployeeDetailsDto()
    //            {

    //                Id = employee.Id,
    //                Name = employee.Name,
    //                Age = employee.Age,
    //                Address = employee.Address,
    //                IsActive = employee.IsActive,
    //                Salary = employee.Salary,
    //                Email = employee.Email,
    //                PhoneNumber = employee.PhoneNumber,
    //                HirringDate = employee.HirringDate,
    //                Gender = employee.Gender,
    //                EmployeeType = employee.EmployeeType,
    //                Department = employee.Department.Name,
    //                DepartmentId = employee.DepartmentId,

    //            };
    //        return null;
    //    }

    //    public int CreateEmployee(CreatedEmployeeDto employeeDto)
    //    {
    //        var employee = new Employee()
    //        {
    //            Name = employeeDto.Name,
    //            Age = employeeDto.Age,
    //            Address = employeeDto.Address,
    //            IsActive = employeeDto.IsActive,
    //            Salary = employeeDto.Salary,
    //            Email = employeeDto.Email,
    //            PhoneNumber = employeeDto.PhoneNumber,
    //            HirringDate = employeeDto.HirringDate,
    //            DepartmentId = employeeDto.DepartmentID,
    //            Gender = employeeDto.Gender,
    //            EmployeeType = employeeDto.EmployeeType,
    //            //CreatedOn = DateTime.UtcNow,//.HasDefaultValueSql("GETDATE()") in employeeconfiguration
    //            CreatedBy = 1,
    //            LastModifiedBy = 1,
    //            LastModifiedOn = DateTime.UtcNow

    //        };
    //        return _employeeRepository.Add(employee);
    //    }

    //    public int UpdateEmployee(UpdatedEmployeeDto employeeDto)
    //    {
    //        var employee = new Employee()
    //        {
    //            Id = employeeDto.Id,
    //            Name = employeeDto.Name,
    //            Age = employeeDto.Age,
    //            Address = employeeDto.Address,
    //            IsActive = employeeDto.IsActive,
    //            Salary = employeeDto.Salary,
    //            Email = employeeDto.Email,
    //            PhoneNumber = employeeDto.PhoneNumber,
    //            HirringDate = employeeDto.HirringDate,
    //            DepartmentId = employeeDto.DepartmentId,
    //            Gender = employeeDto.Gender,
    //            EmployeeType = employeeDto.EmployeeType,
    //            LastModifiedBy = 1,
    //            LastModifiedOn = DateTime.UtcNow

    //        };
    //        return _employeeRepository.Update(employee);
    //    }

    //    public bool DeleteEmployee(int id)
    //    {
    //        var employee = _employeeRepository.Get(id);
    //        if (employee is not null)
    //            return _employeeRepository.Delete(employee) > 0;
    //        return false;
    //    }



    //} 
    #endregion
}

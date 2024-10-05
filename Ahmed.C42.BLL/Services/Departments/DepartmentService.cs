using Ahmed.C42.BLL.CustomModel.Departments;
using Ahmed.C42.DAL.Entities.Departments;
using Ahmed.C42.DAL.Presistence.Repositories.Departments;
using Ahmed.C42.DAL.Presistence.UintOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmed.C42.BLL.Services.Departments
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<DepartmentDto> GetAllDepartmnets()
        {
            #region this issue will get all Department data and you Don't need all this
            //var departments = _unitOfWork.DepartmentRepository.GetAll();

            //#region Manual Mapping

            //#region Without Using Casting Operator
            ////yield return new DepartmentToReturnDto()//yield to return more than one and it used with IEnumerable
            ////{
            ////    Id = department.Id,
            ////    Code = department.Code,
            ////    Name = department.Name,
            ////    Description = department.Description,
            ////    CreationDateTime = department.CreationDateTime,
            ////}; 

            //#endregion    

            //foreach (var department in departments)
            //    yield return (DepartmentToReturnDto) department;

            //#endregion
            //// you can install AutoMapper.dll for automatic mapping 
            #endregion

            var departments = _unitOfWork.DepartmentRepository
                                    .GetAllAsIQueryable()
                                    .Where(X => !X.IsDeleted)
                                    .Select(Department => new DepartmentDto
                                    {
                                        Id = Department.Id,
                                        Code = Department.Code,
                                        Name = Department.Name,
                                        CreationDateTime = Department.CreationDateTime,
                                    })
                                    .AsNoTracking().ToList();//you can use Specification DP

            return departments;
        }

        public DepartmentDetailsDto GetDepartmentById(int id)
        {
            var department = _unitOfWork.DepartmentRepository.Get(id);
            if (department is not null /*is { }//.net8*/)
                return new DepartmentDetailsDto()
                {
                    Id = department.Id,
                    Code = department.Code,
                    Name = department.Name,
                    Description = department.Description,
                    CreationDateTime = department.CreationDateTime,
                    CreatedBy = department.CreatedBy,
                    CreatedOn = department.CreatedOn,
                    LastModifiedBy = department.LastModifiedBy,
                    LastModifiedOn = department.LastModifiedOn,
                };
            return null;

        }

        public int CreateDepartment(CreatedDepartmentDto departmentDto)
        {
            var department = new Department()
            {
                Code = departmentDto.Code,
                Name = departmentDto.Name,
                Description = departmentDto.Description,
                CreationDateTime = departmentDto.CreationDateTime,
                CreatedBy = 1,
                //CreatedOn = DateTime.UtcNow,//.HasDefaultValueSql("GETDATE()") in departmentconfiguration
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.UtcNow,
            };
            _unitOfWork.DepartmentRepository.Add(department);
            return _unitOfWork.Complete();
        }
        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {
            var department = new Department()
            {
                Id = departmentDto.Id,
                Code = departmentDto.Code,
                Name = departmentDto.Name,
                Description = departmentDto.Description,
                CreationDateTime = departmentDto.CreationDateTime,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.UtcNow,
            };
            _unitOfWork.DepartmentRepository.Update(department);
            return _unitOfWork.Complete();
        }

        public bool DeleteDepartment(int id)
        {
            var _departmentRepository = _unitOfWork.DepartmentRepository;
            var department = _departmentRepository.Get(id);
            if (department is not null)
                _departmentRepository.Delete(department);

            return _unitOfWork.Complete() > 0;
        }


    }
}

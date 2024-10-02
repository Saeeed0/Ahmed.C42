using Ahmed.C42.DAL.Entities.Employees;
using Ahmed.C42.DAL.Entities.Employees.Commen.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmed.C42.DAL.Presistence.Data.Configurations.Employees
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Name).HasColumnType("varchar(50)").IsRequired();
            builder.Property(E => E.Address).HasColumnType("varchar(50)");
            builder.Property(E => E.Salary).HasColumnType("decimal(8,2)");

            builder.Property(E => E.Gender)
                .HasConversion(
                
                (gender) => gender.ToString(),
                (gender) => (Gender) Enum.Parse(typeof(Gender), gender)
                
                );

            builder.Property(E => E.EmployeeType)
                .HasConversion(
                
                (emptype) => emptype.ToString(),
                (emptype) => (EmployeeType) Enum.Parse(typeof(EmployeeType), emptype)
                
                );

            builder.Property(E => E.CreatedOn).HasDefaultValueSql("GETUTCDATE()");//when create record will get its value
            builder.Property(E => E.LastModifiedOn).HasComputedColumnSql("GETDATE()");//when you change in record will compute the value(ex:Net Salary)

        }
    }
}

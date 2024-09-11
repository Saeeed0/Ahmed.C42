using Ahmed.C42.DAL.Data.Configurations;
using Ahmed.C42.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ahmed.C42.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        //public ApplicationDbContext():base(new DbContextOptions<ApplicationDbContext>())
        //{//Every Where any code ask obj form ApplicationDbContext the CLR will Create this obj => this issue may case opening More than One Connection with SQL Server

        //}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)//Dependency Injection
        {//Every Where any code ask obj form ApplicationDbContext the CLR will Create this obj depending on the life time that you select(AddSingleton,AddScoped,AddTransient)

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseSqlServer("Server = .; Database = MVCApplication; Trusted_Connection = True; MultipleActiveResultsSets = false;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration<Department>(new DepartmentConfigurations());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Department> Departments { get; set; }
    }
}

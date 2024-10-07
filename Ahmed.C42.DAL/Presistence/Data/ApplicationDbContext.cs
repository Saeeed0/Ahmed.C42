using Ahmed.C42.DAL.Entities.Departments;
using Ahmed.C42.DAL.Entities.Employees;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Ahmed.C42.DAL.Presistence.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //public ApplicationDbContext():base(new DbContextOptions<ApplicationDbContext>())//Without DI
        //{//Every Where any code ask obj form ApplicationDbContext the CLR will Create this obj => this issue may case opening More than One Connection with SQL Server
        //}
        ///
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseSqlServer("Server = DESKTOP-9UUCJQP\\SQLEXPRESS; Database = MVCApplication; Trusted_Connection = True; MultipleActiveResultsSets = false;");
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)//Dependency Injection
        {//Every Where any code ask obj form ApplicationDbContext the CLR will Create this obj depending on the life time that you select(AddSingleton,AddScoped,AddTransient)

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)//You can define relationships (like one-to-many, many-to-many, etc.) between your entities using the Fluent API within OnModelCreating 
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration<Department>(new DepartmentConfigurations());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//ModelBuilder allows you to use the Fluent API to configure entity relationships, keys, constraints, and other database-specific configurations and how your models are mapped compared to data annotations.
        }
        public DbSet<Department> Departments { get; set; }//The DbSet<TEntity> maps an entity class (TEntity) to a corresponding database table
        public DbSet<Employee> Employees { get; set; }

        public DbSet<IdentityUser> IdentityUsers { get; set; }
        public DbSet<IdentityRole> IdentityRoles { get; set; }
    }
}

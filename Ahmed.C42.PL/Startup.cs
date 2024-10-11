using Ahmed.C42.BLL.Common.Attachments;
using Ahmed.C42.BLL.Services.Departments;
using Ahmed.C42.BLL.Services.Employees;
using Ahmed.C42.DAL.Entities.Identity;
using Ahmed.C42.DAL.Presistence.Data;
using Ahmed.C42.DAL.Presistence.Repositories.Departments;
using Ahmed.C42.DAL.Presistence.Repositories.Employees;
using Ahmed.C42.DAL.Presistence.UintOfWork;
using Ahmed.C42.PL.Mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ahmed.C42.PL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the DI container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();// Register Built-In Services Required by MVC

            #region Without using AddDbContext , Configuration.GetConnectionString , Types of Lifetime of Object
            //services.AddTransient<ApplicationDbContext>();
            //services.AddSingleton<ApplicationDbContext>();

            //services.AddScoped<ApplicationDbContext>();//Allow DI for ApplicationDbContext
            //services.AddScoped<DbContextOptions<ApplicationDbContext>>();

            //services.AddDbContext<ApplicationDbContext>();//Instead of Using the Two Previous Methods
            //services.AddDbContext<ApplicationDbContext>(
            //    options => options.UseSqlServer("Server = .; Database = MVCApplication; Trusted_Connection = True; MultipleActiveResultsSets = false;"),
            //    contextLifetime: ServiceLifetime.Scoped,//defualt
            //    optionsLifetime: ServiceLifetime.Scoped //defualt
            //    );

            //services.AddDbContext<ApplicationDbContext>(
            //    options => options.UseSqlServer("Server = DESKTOP-9UUCJQP\\SQLEXPRESS; Database = MVCApplication; Trusted_Connection = True;"
            //    ));//this place not suitable place any developer can see this cretical info 

            //services.AddScoped<ApplicationDbContext>();
            //services.AddScoped<DbContextOptions<ApplicationDbContext>>(serviceProvider =>
            //{
            //    var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            //    optionBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            //    ///////Suppose you need a specific service => You can use serviceProvider and call this service from it
            //    ///////for example
            //    ////using var serviceScope = serviceProvider.CreateScope();
            //    ////var departmentRepo = serviceScope.ServiceProvider.GetService<IDepartmentRepository>();//ask class implementing this interface
            //    return optionBuilder.Options;
            //});

            #endregion

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseLazyLoadingProxies()
                                   .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))//should get DefaultConnection from Decrypt(DefaultConnection) method
                );

            //services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            //services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IEmployeeService, EmployeeService>();



            services.AddTransient<IAttatchmentService, AttachmentService>();

            //services.AddAutoMapper(typeof(MappingProfile));
            services.AddAutoMapper(M => M.AddProfile(new MappingProfile()));


			//services.AddScoped<UserManager<ApplicationUser>>();
			//services.AddScoped<SignInManager<ApplicationUser>>();
			//services.AddScoped<RoleManager<IdentityRole>>();

			//services.AddIdentity<ApplicationUser, IdentityRole>();

			///Register Security Services(Majer and its Dependencies) and Add Configurations
			services.AddIdentity<ApplicationUser, IdentityRole>(option =>
			{
				option.Password.RequireDigit = true;
				option.Password.RequireNonAlphanumeric = true;
				option.Password.RequiredLength = 5;
				option.Password.RequireUppercase = true;
				option.Password.RequireLowercase = true;
				option.Password.RequiredUniqueChars = 1;

				option.User.RequireUniqueEmail = true;
				//option.User.AllowedUserNameCharacters = "asdfhlwer1234";

				option.Lockout.AllowedForNewUsers = true;
				option.Lockout.MaxFailedAccessAttempts = 5;
				option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(50);
			})
				.AddEntityFrameworkStores<ApplicationDbContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/SignIn";
                options.LogoutPath = "/Account/SignIn";
                options.AccessDeniedPath = "/Home/Error";
                options.ExpireTimeSpan = TimeSpan.FromDays(5);
            });

            //services.AddAuthentication();

            //services.AddAuthentication("Aplication.Identity");

            /*services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Aplication.Identity";
                options.DefaultChallengeScheme = "Hamada";

            }).AddCookie("Hamada", displayName: "Asp.Hamada", options =>
			{
				options.LoginPath = "/Account/LogIn";
				options.LogoutPath = "/Account/LogIn";
				options.AccessDeniedPath = "/Home/Error";
				options.ExpireTimeSpan = TimeSpan.FromDays(10);
			});*/



		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); ///ensure that the user has token
            app.UseAuthorization(); /// ensure that the user has role to the action that he intended do 

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

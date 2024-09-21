using Ahmed.C42.BLL.Interfaces;
using Ahmed.C42.BLL.Repositories;
using Ahmed.C42.DAL.Presistence.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
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

            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<DbContextOptions<ApplicationDbContext>>(serviceProvider =>
            {
                var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                ///////Suppose you need a specific service => You can use serviceProvider and call this service from it
                ///////for example
                ////using var serviceScope = serviceProvider.CreateScope();
                ////var departmentRepo = serviceScope.ServiceProvider.GetService<IDepartmentRepository>();//ask class implementing this interface
                return optionBuilder.Options;
            });

            #endregion

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))//should get DefaultConnection from Decrypt(DefaultConnection) method
                );

            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

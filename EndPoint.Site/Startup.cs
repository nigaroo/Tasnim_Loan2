using Tasnim_Loan.Application.Services.Customers.Commands.EditUser;
using Tasnim_Loan.Application.Services.Customers.Commands.RemoveUser;

using Tasnim_Loan.Application.Services.Customers.Commands.UserSatusChange;
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
using Tasnim_Loan.Application.Interfaces.Contexts;
using Tasnim_Loan.Application.Sevices.Customers.Commands.RegisterUser;
using Tasnim_Loan.Application.Sevices.Customers.Queries.GetCustomers;
using Tasnim_Loan.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using Tasnim_Loan.Application.Services.Customers.Commands.UserLogin;
using Tasnim_Loan.Domain.Entities;


namespace EndPoint.Site
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
             options.LoginPath = new PathString("/");
             options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
            });





            services.AddScoped<IDataBaseContext, DataBaseContext>();
            services.AddScoped<IGetCustomersService, GetCustomersService>();
            services.AddScoped<IRegisterCustomerService, RegisterCustomerService>();
            services.AddScoped<IRemoveUserService, RemoveUserService>();
            services.AddScoped<IUserLoginService, UserLoginService>();
            services.AddScoped<IUserSatusChangeService, UserSatusChangeService>();
            services.AddScoped<IEditUserService, EditUserService>();


            string connectionString = "Data Source= NEGAR; Initial Catalog=Tasnim_LoanDb; Integrated Security=True;";
            services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(option => option.UseSqlServer(connectionString));
            services.AddControllersWithViews();
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
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");


                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

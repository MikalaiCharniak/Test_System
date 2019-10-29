using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using CW.TestSystem.DataProvider.DbInfrastracture;
using CW.TestSystem.Identity.Services.Interfaces;
using CW.TestSystem.Identity.Services.Implementation;
using CW.TestSystem.Web.Infrastructure;
using CW.TestSystem.Model.CoreEntities;
using CW.TestSystem.BusinessLogic.Types.Operations;
using CW.TestSystem.BusinessLogic.Types.Models;
using HotChocolate.AspNetCore;
using HotChocolate;

namespace CW.TestSystem.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TestSystemDbContext>(options =>
                    options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddLogging(builder => builder.AddConsole());
            services.AddScoped<IAccountService, AccountService>();
            services.AddGraphQL(sp => SchemaBuilder.New()
            .AddQueryType<QueryType>().
            AddType<TestType>().
            AddType<QuestionType>().
            AddType<UserType>().
            AddType<AnswerType>().
            AddType<ResultType>().
            AddType<TagType>()
            .Create());
            services.AddIdentity<User, Role>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = false;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;

            }).AddEntityFrameworkStores<TestSystemDbContext>()
            .AddDefaultTokenProviders().AddRoles<Role>();
            services.AddAuthorization();
            services.AddControllersWithViews();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseJwtTokenInHttpOnlyCookie();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseRouting();
            app.UseGraphQL();
            app.UseGraphiQL();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
            //app.UseSpa(spa =>
            //{
            //    spa.Options.SourcePath = "ClientApp";

            //    if (env.IsDevelopment())
            //    {
            //        spa.UseReactDevelopmentServer(npmScript: "start");
            //    }
            //});
        }
    }
}

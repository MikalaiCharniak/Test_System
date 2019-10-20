using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using CW.TestSystem.DataProvider.DbInfrastracture;
using CW.TestSystem.Identity.Services.Interfaces;
using CW.TestSystem.Identity.Services.Implementation;
using CW.TestSystem.Model.CoreEntities;
using CW.TestSystem.Web.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Voyager;
using CW.TestSystem.GraphQLTypes.ObjectTypes;
using HotChocolate.Execution.Configuration;
using CW.TestSystem.GraphQLTypes.OperationTypes;

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
            services.AddGraphQL(sp => SchemaBuilder.New()
               .AddServices(sp)
            .AddAuthorizeDirectiveType()
            .AddQueryType<QueryType>()
            .AddType<TestType>()
            .AddType<QuestionType>()
            .AddType<ResultType>()
            .AddType<AnswerType>()
            .AddType<UserType>()
            .AddType<TagType>()
            .Create(),
            new QueryExecutionOptions
            {
                MaxOperationComplexity = 10,
                UseComplexityMultipliers = true
            });
            services.AddScoped<IAccountService, AccountService>();
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
            services.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(config =>
            {
                config.RequireHttpsMetadata = true;
                config.SaveToken = true;
                config.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = Configuration["JWT:Issuer"],
                    ValidAudience = Configuration["JWT:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:SecretKey"])),
                    ClockSkew = TimeSpan.Zero
                };
            });
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
            app.UsePlayground();
            app.UseVoyager();
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

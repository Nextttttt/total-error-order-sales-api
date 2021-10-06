using System.Reflection;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TotalError.OrderSales.Api.ExtansionMethods;
using TotalError.OrderSales.Api.Middleware;
using TotalError.OrderSales.Data;

namespace CompanyName.ProjectName.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });
            services.AddAutofac();
            services.AddHttpContextAccessor();
            services.AddLogging();

            services.AddTotalErrorSwagger();
            services.AddTotalErrorAuth(Configuration);
            services.AddTotalErrorRepositories(Configuration);
            services.AddTotalErrorServices();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, TotalErrorDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ErrorHandlerMiddleware>();

            dbContext.Database.Migrate();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
            });
        }
    }
}
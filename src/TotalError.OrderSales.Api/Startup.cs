using System.Reflection;
using Autofac;
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
using TotalError.OrderSales.Data.Repositories;
using TotalError.OrderSales.Domain.Abstractions.Helpers;
using TotalError.OrderSales.Services;

namespace TotalError.OrderSales.Api
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

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(BaseRepository<,>)))
                   .Where(t => t.Name.EndsWith("Repository"))
                   .InstancePerLifetimeScope()
                   .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(BaseService<>)))
                   .Where(t => t.Name.EndsWith("Service"))
                   .InstancePerLifetimeScope()
                   .AsImplementedInterfaces();

            builder.RegisterType<KeyDerivationWrapper>().As<IKeyDerivationWrapper>().InstancePerLifetimeScope();
            builder.RegisterType<SaltGenerator>().As<ISaltGenerator>().InstancePerLifetimeScope();
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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Gateway v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
            });
        }
    }
}
using AspnetCore.DapperVsEFCore.DapperAdapter;
using AspnetCore.DapperVsEFCore.EFCoreAdapter;
using AspnetCoreApi.DapperVsEFCore.WebApi.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependecyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace AspnetCoreApi.DapperVsEFCore.WebApi
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
            services.AddControllers();      

            services
                .AddDapperAdapter(Configuration.SafeGet<DapperAdapterConfiguration>())
                .AddEFCoreAdapter(Configuration.SafeGet<EFCoreConfiguration>());
  
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Micro ORM Dapper", Version = "v1" });
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "ORM Entity Framework Core", Version = "v2" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Micro ORM Dapper v1");
                    c.SwaggerEndpoint("/swagger/v2/swagger.json", "ORM Entity Framework Core v2");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

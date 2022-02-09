using AspnetCore.DapperVsEFCore.Domain.Interfaces.Repositories;
using AspnetCore.DapperVsEFCore.EFCoreAdapter;
using AspnetCore.DapperVsEFCore.EFCoreAdapter.Context;
using AspnetCore.DapperVsEFCore.EFCoreAdapter.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Microsoft.Extensions.DependecyInjection
{
    public static class EFCoreServiceCollectionExtensions
    {
        public static IServiceCollection AddEFCoreAdapter(this IServiceCollection services, EFCoreConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            services.AddSingleton(configuration);
            
            services.AddScoped<IAutorEFCoreRepository, AutorRepository>();
            services.AddScoped<ILivroEFCoreRepository, LivroRepository>();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.ConnectionString)
            );

            return services;
        }
    }
}

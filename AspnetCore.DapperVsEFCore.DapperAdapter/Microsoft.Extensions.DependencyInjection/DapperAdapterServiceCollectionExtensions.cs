using AspnetCore.DapperVsEFCore.DapperAdapter;
using AspnetCore.DapperVsEFCore.DapperAdapter.Mappings;
using AspnetCore.DapperVsEFCore.DapperAdapter.Repositories;
using AspnetCore.DapperVsEFCore.Domain.Interfaces.Repositories;
using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DapperAdapterServiceCollectionExtensions
    {
        public static IServiceCollection AddDapperAdapter(this IServiceCollection services, DapperAdapterConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            services.AddSingleton(configuration);

            services.AddScoped<IAutorDapperRepository, AutorRepository>();
            services.AddScoped<ILivroDapperRepository, LivroRepository>();
            services.AddScoped<IDbConnection, SqlConnection>();
            services.AddScoped(d =>
            {            
                return new SqlConnection(configuration.ConnectionString);
            });         

            InitializeFluentMapper();

            return services;
        }

        public static void InitializeFluentMapper()
        {
            if (FluentMapper.EntityMaps.IsEmpty)
            {
                FluentMapper.Initialize(c =>
                {
                    c.AddMap(new LivroMap());
                    c.AddMap(new ArtigoMap());
                    c.AddMap(new AutorMap());                    
                    c.ForDommel();
                });
            }
        }
    }
}

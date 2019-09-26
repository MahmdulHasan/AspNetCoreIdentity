using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanelBoard.Data.Extension
{
    using Data.Mapping;
    public static class PanelServiceExtension
    {
        public static IServiceCollection AddPanelExtension(this IServiceCollection services, string connectionStringName, string migrationAssemblyName)
        {
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();

            services = services.AddScoped(sp =>
                 new PanelDbContext(configuration.GetConnectionString(connectionStringName), migrationAssemblyName));


            services = services.AddDbContext<PanelDbContext>(options =>
                               options.UseSqlServer(configuration.GetConnectionString(connectionStringName),
                               b => b.MigrationsAssembly(migrationAssemblyName)


                            )
                               
                               );


           

            services.AddAutoMapper(typeof(PanelServiceExtension).Assembly);

            return services;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PanelBoard.Web
{
    using Autofac;
    using Autofac.Extensions.DependencyInjection;
    using Membership.Extension;
    using Data;
    using Data.Extension;
    using PanelBoard.Membership;
    using Data.Seeds;
    using JqueryDataTables.ServerSide.AspNetCoreWeb.DependencyInjection;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public static IContainer AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var connectionStringName = "DefaultConnection";
            var migrationAssemblyName = typeof(Startup).Assembly.FullName;

            

            services.AddMembershipExtension(connectionStringName, migrationAssemblyName);
            services.AddPanelExtension(connectionStringName, migrationAssemblyName);


            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromSeconds(100);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
               }
             );

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddJqueryDataTables();


            services.AddEntityFrameworkSqlServer();

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterMembershipModule(Configuration, connectionStringName, migrationAssemblyName);
            builder.RegisterModule(new PanelModule(Configuration, connectionStringName, migrationAssemblyName));
            AutofacContainer = builder.Build();

            return new AutofacServiceProvider(AutofacContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public  void Configure(IApplicationBuilder app, IHostingEnvironment env, AaaSeed aaaSeed, StudentSeed sSeed)
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
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            aaaSeed.MigrateAsync().Wait();
            aaaSeed.SeedAsync().Wait();

            sSeed.MigrateAsync().Wait();
            sSeed.SeedAsync();

        }
    }
}

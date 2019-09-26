using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PanelBoard.Membership.Entities;
using PanelBoard.Membership.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanelBoard.Membership.Extension
{
    using Mapping;
    public static class MemberShipServiceCollectionExtension
    {
        public static (IdentityBuilder, AuthenticationBuilder) AddMembershipExtension(this IServiceCollection services, string connectionStringName, string migrationAssemblyName)
        {
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();

            var iBuilder = services
               .AddIdentity<User, Role>()
               .AddEntityFrameworkStores<AaaDbContext>()
               .AddUserManager<UserManager>()
               .AddRoleManager<RoleManager>()
               .AddSignInManager<SignInManager>();



            var aBuilder = services.AddAuthentication()
                .AddCookie("S4BB", options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.LogoutPath = "/Account/Logout";
                    options.AccessDeniedPath = "/Account/AccessDenied";
                    options.ReturnUrlParameter = "returnUrl";
                });

            services.AddDbContext<AaaDbContext>(options =>
              options.UseSqlServer(
                  configuration.GetConnectionString(connectionStringName),
                  b => b.MigrationsAssembly(migrationAssemblyName)
              )
          );




            Mapper.Initialize(cfg => { cfg.AddProfile<MembershipMappingProfile>();
                cfg.ValidateInlineMaps = false;
            });
            
            

            services.AddAutoMapper(typeof(MemberShipServiceCollectionExtension).Assembly);

            return (iBuilder, aBuilder);








        }
    }
}

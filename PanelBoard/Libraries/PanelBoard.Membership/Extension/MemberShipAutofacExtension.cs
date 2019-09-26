using Autofac;
using Autofac.Core.Registration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanelBoard.Membership.Extension
{
    public static class MemberShipAutofacExtension
    {
        public static IModuleRegistrar RegisterMembershipModule(this ContainerBuilder cb, IConfiguration configuration, string connectionStringName, string migrationAssembly)
        {
            return cb.RegisterModule(new MembershipModule(configuration, connectionStringName, migrationAssembly));
        }
    }
}

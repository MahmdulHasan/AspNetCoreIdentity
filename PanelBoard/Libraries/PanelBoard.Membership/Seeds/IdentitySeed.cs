using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PanelBoard.Membership.Seeds
{
    public abstract class IdentitySeed
            : ISeed
    {
        protected readonly DbContext Context;

        public IdentitySeed(DbContext context)
        {
            Context = context;
        }

        public async Task MigrateAsync()
        {
            await Context.Database.MigrateAsync();
        }
        public abstract Task SeedAsync();

       
    }
}

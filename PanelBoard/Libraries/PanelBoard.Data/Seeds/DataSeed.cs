using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PanelBoard.Data.Seeds
{
 
    public abstract class DataSeed
            : ISeed
    {
        protected readonly DbContext Context;

        public DataSeed(DbContext context)
        {
            Context = context;
        }

        public async Task MigrateAsync()
        {
            await Context.Database.MigrateAsync();
        }
        public abstract void SeedAsync();
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PanelBoard.Membership.Seeds
{
   public interface ISeed
    {
        Task MigrateAsync();
        Task SeedAsync();
    }
}

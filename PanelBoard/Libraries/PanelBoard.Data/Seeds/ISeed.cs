using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PanelBoard.Data
{
    public interface ISeed
    {
        Task MigrateAsync();
        void SeedAsync();
    }
}

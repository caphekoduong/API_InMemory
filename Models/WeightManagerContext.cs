using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_THC_Inventory.Models
{
    public class WeightManagerContext: DbContext
    {
        public WeightManagerContext (DbContextOptions<WeightManagerContext> options) : base(options)
        {

        }
        public DbSet<WeightManager> WeightManagers { get; set; }

    }
}

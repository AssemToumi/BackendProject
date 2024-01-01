using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;

namespace DistributionService.Data
{
    public class DistributionServiceContext : DbContext
    {
        public DistributionServiceContext (DbContextOptions<DistributionServiceContext> options)
            : base(options)
        {
        }

        public DbSet<BusinessObjects.Order>? Distribution { get; set; }
    }
}

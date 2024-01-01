using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;

namespace MonitoringService.Data
{
    public class MonitoringServiceContext : DbContext
    {
        public MonitoringServiceContext (DbContextOptions<MonitoringServiceContext> options)
            : base(options)
        {
        }

        public DbSet<BusinessObjects.Order>? Monitoring { get; set; }
    }
}

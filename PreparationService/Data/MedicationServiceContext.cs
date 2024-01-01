using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;

namespace PreparationService.Data
{
    public class PreparationServiceContext : DbContext
    {
        public PreparationServiceContext(DbContextOptions<PreparationServiceContext> options)
            : base(options)
        {
        }

        public DbSet<BusinessObjects.Medication>? Preparation { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;

namespace StorageService.Data
{
    public class StorageServiceContext : DbContext
    {
        public StorageServiceContext(DbContextOptions<StorageServiceContext> options)
            : base(options)
        {
        }

        public DbSet<BusinessObjects.Order>? Storage { get; set; }
    }
}

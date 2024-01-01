using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;

namespace ValidationService.Data
{
    public class ValidationServiceContext : DbContext
    {
        public ValidationServiceContext(DbContextOptions<ValidationServiceContext> options)
            : base(options)
        {
        }

        public DbSet<BusinessObjects.Order>? Validation { get; set; }
    }
}

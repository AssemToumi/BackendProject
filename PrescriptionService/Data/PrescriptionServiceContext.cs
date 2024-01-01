using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;

namespace PrescriptionService.Data
{
    public class PrescriptionServiceContext : DbContext
    {
        public PrescriptionServiceContext(DbContextOptions<PrescriptionServiceContext> options)
            : base(options)
        {
        }

        public DbSet<BusinessObjects.Patient>? Prescription { get; set; }
    }
}

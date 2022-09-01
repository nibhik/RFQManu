using Microsoft.EntityFrameworkCore;
using RFQManufactMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RFQManufactMicroservice.Context
{
    public class RFQDbContext:DbContext
    {
   
        public RFQDbContext(DbContextOptions<RFQDbContext> options) : base(options)
        {
        }
        public DbSet<Rfq> RFQ { get; set; }
        public DbSet<PartReorderDetails> PartReorderDetails { get; set; }
        public DbSet<Supplier> SUPPLIER { get; set; }
    }
}

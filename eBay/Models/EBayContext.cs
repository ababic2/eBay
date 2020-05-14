using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBay.Models
{
    public class EBayContext : DbContext
    {
        public EBayContext(DbContextOptions<EBayContext> options) : base(options) { 
        }

        public DbSet<Proizvod> Proizvod { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBulider)
        {
            modelBulider.Entity<Proizvod>().ToTable("Proizvod");
        }
    }
}

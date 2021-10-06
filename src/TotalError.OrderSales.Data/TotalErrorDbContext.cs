using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalError.OrderSales.Data.Entities;

namespace TotalError.OrderSales.Data
{
    public class TotalErrorDbContext : DbContext
    {
        public TotalErrorDbContext(DbContextOptions<TotalErrorDbContext> options)
            :base(options)
        {

        }

        public DbSet<OrderEntity> Orders { get; set; }

        public DbSet<SaleEntity> Sales { get; set; }

        public DbSet<ItemEntity> Items { get; set; }

        public DbSet<RegionEntity> Regions { get; set; }

        public DbSet<CountryEntity> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

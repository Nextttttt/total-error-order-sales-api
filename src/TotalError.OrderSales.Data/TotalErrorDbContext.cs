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

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<OrderEntity> Orders { get; set; }

        public DbSet<SaleEntity> Sales { get; set; }

        public DbSet<ItemEntity> Items { get; set; }

        public DbSet<RegionEntity> Regions { get; set; }

        public DbSet<CountryEntity> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RegionEntity>()
                .HasMany(r => r.Countries)
                .WithOne(c => c.Region)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RegionEntity>()
                .HasMany(r => r.Orders)
                .WithOne(o => o.Region)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrderEntity>()
                .HasOne(o => o.Region)
                .WithMany(r => r.Orders)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SaleEntity>()
                .Property(s => s.TotalProfit).HasColumnType("money");

            modelBuilder.Entity<SaleEntity>()
                .Property(s => s.TotalCost).HasColumnType("money");

            modelBuilder.Entity<SaleEntity>()
                .Property(s => s.TotalRevenue).HasColumnType("money");

            modelBuilder.Entity<SaleEntity>()
                .Property(s => s.UnitPrice).HasColumnType("money");

            modelBuilder.Entity<ItemEntity>()
                .Property(i => i.UnitCost).HasColumnType("smallmoney");

        }
    }
}

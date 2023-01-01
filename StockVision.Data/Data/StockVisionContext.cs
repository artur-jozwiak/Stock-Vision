using Microsoft.EntityFrameworkCore;
using StockVision.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockVision.Data.Data
{
    public class StockVisionContext : DbContext
    {
        public StockVisionContext()
        {

        }
        public StockVisionContext(DbContextOptions<StockVisionContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
          //  optionsBuilder.EnableSensitiveDataLogging();
            //optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=StockVision;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");
            //optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }

        public DbSet<OrderBook> OrderBooks { get; set; }
        public DbSet<AskOrderBook> AskOrderBooks { get; set; }
        public DbSet<BidOrderBook> BidOrderBooks { get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<StockIndex> StockIndexes { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<IndexAssignment> IndexAssignment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var fullOrderBook = modelBuilder.Entity<OrderBook>();
            var askOrderBook = modelBuilder.Entity<AskOrderBook>();
            var bidOrderBook = modelBuilder.Entity<BidOrderBook>();
            var order = modelBuilder.Entity<Order>();
            var company = modelBuilder.Entity<Company>();

            fullOrderBook.HasOne(f => f.AskOrderBook).WithOne().HasForeignKey<OrderBook>(a => a.AskOrderBookId);
            fullOrderBook.HasOne(f => f.BidOrderBook ).WithOne().HasForeignKey<OrderBook>(a => a.BidOrderBookId);

            order.Property(o => o.Price).HasPrecision(9,4);
            order.Property(o => o.OrdersValue).HasPrecision(13, 4);
            order.Property(o => o.SharePercentage).HasPrecision(5, 2);

            company.Property(c => c.Name).HasMaxLength(100);
            company.Property(c => c.Symbol).HasMaxLength(10);
            company.HasOne(c => c.OrderBook).WithOne().HasForeignKey<Company>(a => a.OrderBookId);
            company.HasMany(c => c.StockIndexes)
                   .WithMany(i => i.Companies)
                   .UsingEntity<IndexAssignment>(
                    ci => ci.HasOne(ci => ci.StockIndex).WithMany( i => i.IndexAssignment).HasForeignKey(ci => ci.StockIndexId),
                    ci => ci.HasOne(ci => ci.Company).WithMany(c => c.IndexAssignment).HasForeignKey(ci => ci.CompanyId)
                    );
            company.HasOne( c => c.Sector).WithMany(s => s.Companies).HasForeignKey(c => c.SectorId);
        }
    }
}

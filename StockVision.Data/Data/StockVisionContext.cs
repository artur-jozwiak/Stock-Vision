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
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=StockVision;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");
            //optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }

        public virtual DbSet<OrderBook> OrderBooks { get; set; }
        public virtual DbSet<AskOrderBook> AskOrderBooks { get; set; }
        public virtual DbSet<BidOrderBook> BidOrderBooks { get; set; }
        public virtual DbSet<Order> Orders{ get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<StockIndex> StockIndexes { get; set; }
        public virtual DbSet<Sector> Sectors { get; set; }
        public virtual DbSet<IndexAssignment> IndexAssignment { get; set; }
        public virtual DbSet<Forecast> Forecasts { get; set; }
        public virtual DbSet<Wallet> Wallets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var fullOrderBook = modelBuilder.Entity<OrderBook>();
            var order = modelBuilder.Entity<Order>();
            var company = modelBuilder.Entity<Company>();
            var stockIndex = modelBuilder.Entity<StockIndex>();
            var sector = modelBuilder.Entity<Sector>();
            var forecast = modelBuilder.Entity<Forecast>();

            fullOrderBook.HasOne(f => f.AskOrderBook).WithOne().HasForeignKey<OrderBook>(a => a.AskOrderBookId);
            fullOrderBook.HasOne(f => f.BidOrderBook ).WithOne().HasForeignKey<OrderBook>(a => a.BidOrderBookId);

            order.Property(o => o.Price).HasPrecision(9,4);
            order.Property(o => o.OrdersValue).HasPrecision(13, 4);
            order.Property(o => o.SharePercentage).HasPrecision(5, 2);

            company.Property(c => c.Name).HasMaxLength(100);
            company.Property(c => c.Symbol).HasMaxLength(10);
            //company.HasOne(c => c.OrderBook).WithOne().HasForeignKey<Company>(a => a.OrderBookId);
            company.HasMany(c => c.StockIndexes)
                   .WithMany(i => i.Companies)
                   .UsingEntity<IndexAssignment>(
                    ci => ci.HasOne(ci => ci.StockIndex).WithMany( i => i.IndexAssignment).HasForeignKey(ci => ci.StockIndexId),
                    ci => ci.HasOne(ci => ci.Company).WithMany(c => c.IndexAssignment).HasForeignKey(ci => ci.CompanyId));
            company.HasOne( c => c.Sector).WithMany(s => s.Companies).HasForeignKey(c => c.SectorId);

            stockIndex.Property(i => i.Name).HasMaxLength(50);

            sector.Property(s => s.Name).HasMaxLength(50);

            forecast.Property(c => c.Result).HasPrecision(7,3);
            forecast.Property(c => c.AskOrderBookDifference).HasPrecision(4, 2);
            forecast.Property(c => c.BidOrderBookDifference).HasPrecision(4, 2);
        }
    }
}

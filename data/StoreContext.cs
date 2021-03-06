using JsonReports.Models;
using Microsoft.EntityFrameworkCore;

namespace JsonReports.Data
{
    public class StoreContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Sale>()
                .Property(s => s.Amount)
                .HasColumnType("decimal(15,2)");

            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Customer)
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Seller)
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Seller> Sellers { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
    }
}
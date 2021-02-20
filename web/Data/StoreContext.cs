using JsonReports.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace JsonReports.Web.Data
{
    public class StoreContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Seller> Sellers { get; set; }

        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
    }
}
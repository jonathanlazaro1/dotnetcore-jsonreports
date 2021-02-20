using JsonReports.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace JsonReports.Web.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
    }
}
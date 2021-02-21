using System.Linq;
using JsonReports.Data.Generators;

namespace JsonReports.Data.Utils
{
    public static class StoreContextPopulator
    {
        public static void Populate(StoreContext db)
        {
            if (db.Sales.Count() > 0) return;

            var generator = StoreDataGenerator.Init(6, 70, 100);
            db.Sellers.AddRange(generator.Sellers);
            db.Customers.AddRange(generator.Customers);
            db.Sales.AddRange(generator.Sales);

            db.SaveChanges();
        }
    }
}
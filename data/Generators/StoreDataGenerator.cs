using System.Collections.Generic;
using Bogus;
using JsonReports.Models;

namespace JsonReports.Data.Generators
{
    public class StoreDataGenerator
    {
        public List<Seller> Sellers = new List<Seller>();

        public List<Customer> Customers = new List<Customer>();

        public List<Sale> Sales = new List<Sale>();

        public static StoreDataGenerator Init(int sellersCount, int customersCount, int salesCount)
        {
            var generator = new StoreDataGenerator();

            var sellerId = 1;
            var sellerFaker = new Faker<Seller>()
               .RuleFor(s => s.Id, _ => sellerId++)
               .RuleFor(s => s.Name, f => f.Name.FullName());

            var customerId = 1;
            var customerFaker = new Faker<Customer>()
               .RuleFor(c => c.Id, _ => customerId++)
               .RuleFor(c => c.Name, f => f.Name.FullName());

            var sellers = sellerFaker.Generate(sellersCount);
            generator.Sellers.AddRange(sellers);
            var customers = customerFaker.Generate(customersCount);
            generator.Customers.AddRange(customers);

            var saleId = 1;
            var saleFaker = new Faker<Sale>()
               .RuleFor(s => s.Id, _ => saleId++)
               .RuleFor(s => s.Date, f => f.Date.Past())
               .RuleFor(s => s.SellerId, f => f.Random.Int(1, generator.Sellers.Count))
               .RuleFor(s => s.CustomerId, f => f.Random.Int(1, generator.Customers.Count))
               .RuleFor(s => s.Amount, f => f.Random.Decimal(1, 1000));


            var sales = saleFaker.Generate(salesCount);

            generator.Sales.AddRange(sales);

            return generator;
        }
    }
}
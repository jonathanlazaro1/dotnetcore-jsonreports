using System.Linq;
using System.Threading.Tasks;
using JsonReports.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JsonReports.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly StoreContext _storeDbContext;

        public SalesController(StoreContext storeDbContext)
        {
            this._storeDbContext = storeDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetSalesAsync(int count = 10)
        {
            var sales = await this._storeDbContext.Sales
            .OrderByDescending(s => s.Date)
            .Take(count)
            .Select(s => new
            {
                s.Id,
                s.Date,
                SellerId = s.SellerId,
                Seller = s.Seller.Name,
                Customer = s.Customer.Name,
                s.Amount
            })
            .ToListAsync();

            return Ok(sales);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Rockets_Elevators_web_api;
using Microsoft.EntityFrameworkCore;

namespace Rockets_Elevators_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly rocket_peterpanContext _context;
        public CustomerController(rocket_peterpanContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            List<string> customrName = new List<string>();
            for (int i = 0; i < customers.Count; i++ )
            {
                customrName.Add(customers[i].FullName);
            }
            return Ok(customrName);

        }
    }
}
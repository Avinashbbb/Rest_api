using Microsoft.AspNetCore.Mvc;
using Rockets_Elevators_web_api;
using Microsoft.EntityFrameworkCore;

namespace Rockets_Elevators_web_api.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadController : ControllerBase{
        private readonly rocket_peterpanContext _context;

        public LeadController(rocket_peterpanContext context) => _context = context;
        
        [HttpGet]
        public async Task<IActionResult> GetLeads()
        {
            DateTime days = DateTime.Now.AddDays(-30);
            DateTime today = DateTime.Now;
            bool bol = true;
            var customer = await _context.Customers.ToListAsync();
            List<string> customerEmail = new List<string>();
            for( int i = 0 ; i <customer.Count; i++ )
            {
                customerEmail.Add(customer[i].Email);
            }
            var lead = _context.Leads.Where(l => (l.Date > days & l.Date <today ) && (bol != customerEmail.Contains(l.Email)));
            if (lead == null)
            {
                return NotFound();
            }
            return  Ok(lead);
        }
    }
}
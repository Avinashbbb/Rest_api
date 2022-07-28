using Microsoft.AspNetCore.Mvc;
using Rockets_Elevators_web_api;
using Microsoft.EntityFrameworkCore;

namespace Rockets_Elevators_web_api.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class BatteryController : ControllerBase{
        private readonly rocket_peterpanContext _context;
        public BatteryController(rocket_peterpanContext context) => _context = context;
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBatteryStatusById(long id){
            var battery = _context.Batteries.Where(b => b.Id == id).Select(b => new BatteryStatus(){Status = b.Status});
            return battery == null ? NotFound() : Ok(battery);
        }
        [HttpPut("{id}/{status}")]
        public async Task<IActionResult> UpdateBatteryStatusById(long id, String status){
            var battery = _context.Batteries.FirstOrDefault(b => b.Id == id);
            if (battery == null) return NotFound();
            battery.Status = status;
            await _context.SaveChangesAsync();
            return battery == null ? NotFound() : Ok(battery);
        }
    }
}
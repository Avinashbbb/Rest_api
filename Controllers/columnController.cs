using Microsoft.AspNetCore.Mvc;
using Rockets_Elevators_web_api;
using Microsoft.EntityFrameworkCore;

namespace Rockets_Elevators_web_api.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class ColumnController : ControllerBase{
        private readonly rocket_peterpanContext _context;
        public ColumnController(rocket_peterpanContext context) => _context = context;
        [HttpGet("{id}")]
        public async Task<IActionResult> GetColumnStatusById(long id){
            var column = _context.Columns.Where(c => c.Id == id).Select(c => new ColumnStatus(){Status = c.Status});
            return column == null ? NotFound() : Ok(column);
        }
        [HttpPut("{id}/{status}")]
        public async Task<IActionResult> UpdateColumnStatusById(long id, String status){
            var column = _context.Columns.FirstOrDefault(c => c.Id == id);
            if (column == null) return NotFound();
            column.Status = status;
            await _context.SaveChangesAsync();
            return column == null ? NotFound() : Ok(column);
        }
    }
}
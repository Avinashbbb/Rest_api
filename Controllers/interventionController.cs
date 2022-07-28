using Microsoft.AspNetCore.Mvc;
using Rockets_Elevators_web_api;
using Microsoft.EntityFrameworkCore;

namespace Rockets_Elevators_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterventionController : ControllerBase
    {
        private readonly rocket_peterpanContext _context;

        public InterventionController(rocket_peterpanContext context) => _context = context;
        
        [HttpGet("{status}")]//("{id}")
        public async Task<IActionResult> GetInterventionBystatus(string status)
        {
            var intervention =  _context.Interventions.Where(i => (i.status == status) && (i.interventionDateStart == null || i.interventionDateStart == "nil"));
            if (intervention == null) return NotFound();
            return Ok(intervention);
        }

        [HttpPut("{id}/{status}/start/{interventionDateStart}")]
        public async Task<IActionResult> ChangeStatusAndStartDate(long id,string status,string interventionDateStart)
        {
            // var intervention = _context.Interventions.Where(i => i.id == id);
            var intervention = _context.Interventions.Find(id);
            if (intervention == null) return NotFound();
            intervention.status = status;
            intervention.interventionDateStart = interventionDateStart;
            await _context.SaveChangesAsync();
            return Ok(intervention);

        }

        [HttpPut("{id}/{status}/end/{interventionDateEnd}")]
        public async Task<IActionResult> ChangeStatusAndEndDate(long id,string status,string interventionDateEnd)
        {
            // var intervention = _context.Interventions.Where(i => i.id == id);
            var intervention = _context.Interventions.Find(id);
            if (intervention == null) return NotFound();
            intervention.status = status;
            intervention.interventionDateEnd = interventionDateEnd;
            await _context.SaveChangesAsync();
            return Ok(intervention);
        }

    }
}
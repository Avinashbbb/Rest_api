using Microsoft.AspNetCore.Mvc;
using Rockets_Elevators_web_api;
using Microsoft.EntityFrameworkCore;

namespace Rockets_Elevators_web_api.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase{
        private readonly rocket_peterpanContext _context;

        public BuildingController(rocket_peterpanContext context) => _context = context;

        [HttpGet]
        public IEnumerable<Building> GetBatteries() {
            return _context.Buildings; 
        }  
    }
}
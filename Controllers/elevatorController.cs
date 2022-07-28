using Microsoft.AspNetCore.Mvc;
using Rockets_Elevators_web_api;
using Microsoft.EntityFrameworkCore;

namespace Rockets_Elevators_web_api.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class ElevatorController : ControllerBase{
        private readonly rocket_peterpanContext _context;
        public ElevatorController(rocket_peterpanContext context) => _context = context;
        [HttpGet]
        public async Task<IEnumerable<Elevator>> GetElevatorsWhoNeedIntervention() => _context.Elevators.Select(e => new Elevator(){
            Id = e.Id,
            SerialNumber = e.SerialNumber,
            CompanyName = e.CompanyName,
            Model = e.Model,
            FullName = e.FullName,
            Email = e.Email,
            Types = e.Types,
            Status = e.Status,
            DateCommissioning = e.DateCommissioning,
            DateLastInspection = e.DateLastInspection,
            CertificateOperations = e.CertificateOperations,
            Information = e.Information
            }).Where(e => e.Status == "notInOperation");

        [HttpGet("{id}")]
        public async Task<IActionResult> GetElevatorStatusById(long id){
            var elevator = _context.Elevators.Where(e => e.Id == id).Select(e => new ElevatorStatus(){Status = e.Status});
            return elevator == null ? NotFound() : Ok(elevator);
        }
        [HttpPut("{id}/{status}")]
        public async Task<IActionResult> UpdateElevatorStatusById(long id, String status){
            var elevator = _context.Elevators.FirstOrDefault(e => e.Id == id);
            if (elevator == null) return NotFound();
            elevator.Status = status;
            await _context.SaveChangesAsync();
            return elevator == null ? NotFound() : Ok(elevator);
        }
    }
}
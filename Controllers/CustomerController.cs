using Microsoft.AspNetCore.Mvc;
using Rockets_Elevators_web_api;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace Rockets_Elevators_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly rocket_peterpanContext _context;
        public CustomerController(rocket_peterpanContext context) => _context = context;

        // gets all the customers.
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            return Ok(customers);
        }

        [HttpGet("/customerobj/{email}")]
        public async Task<IActionResult> GetCustomerObject(string email)
        {
            var customers =  _context.Customers.Where(c => c.Email == email);
            return Ok(customers);
        }

        //gives building address
        [HttpGet("/buildingaddress/{id}")]// customer id
        public async Task<IActionResult> GetCustomerBuildingAdress(long id)
        {
            var customerBuildings =  _context.Buildings.Where(b => b.CustomerId == id);
            List<string> customerBuildingAddress = new List<string>();
            foreach (var item in customerBuildings)
            {
                customerBuildingAddress.Add(item.AddressOfBuilding);
            }
            return Ok(customerBuildingAddress);
        }

        //gives building 
        [HttpGet("/building/{id}")]// customer id
        public async Task<IActionResult> GetCustomerBuilding(long id)
        {
            var customerBuildings =  _context.Buildings.Where(b => b.CustomerId == id);
            return Ok(customerBuildings);
        }
    
        //gives battery
        [HttpGet("/battery/{id}")]//building id
        public async Task<IActionResult> GetCustomerBattery(long id)
        {
            var customerBattery = _context.Batteries.Where(b => b.BuildingId == id);
            return Ok(customerBattery);
        }
        //gives battery id
        [HttpGet("/batteryid/{id}")]//building id
        public async Task<IActionResult> GetCustomerBatteryId(long id)
        {
            var customerBattery = _context.Batteries.Where(b => b.BuildingId == id);
            List<long> customerBatteryId = new List<long>();
            foreach (var item in customerBattery)
            {
                customerBatteryId.Add(item.Id);
            }
            return Ok(customerBatteryId);
        }
        //gives column
        [HttpGet("/column/{id}")]//battery id
        public async Task<IActionResult> GetCustomerColumn(long id)
        {
            var customerColumn = _context.Columns.Where(c => c.BatterieId == id);
            return Ok(customerColumn);
        }

        //gives columnid
        [HttpGet("/columnid/{id}")]//battery id
        public async Task<IActionResult> GetCustomerColumnid(long id)
        {
            var customerColumn = _context.Columns.Where(c => c.BatterieId == id);
            List<long> customerColumnId = new List<long>();
            foreach (var item in customerColumn)
            {
                customerColumnId.Add(item.Id);
            }
            return Ok(customerColumnId);
        }
        //gives elevator
        [HttpGet("/elevator/{id}")]//column id
        public async Task<IActionResult> GetCustomerElevator(long id)
        {
            var customerElevator = _context.Elevators.Where(c => c.ColumnId == id);
            return Ok(customerElevator);
        }

        //gives elevatorid
        [HttpGet("/elevatorid/{id}")]//column id
        public async Task<IActionResult> GetCustomerElevatorid(long id)
        {
            var customerElevator = _context.Elevators.Where(c => c.ColumnId == id);
            List<long> customerElevatorId = new List<long>();
            foreach (var item in customerElevator)
            {
                customerElevatorId.Add(item.Id);
            }
            return Ok(customerElevatorId);
        }

        [HttpPost]
        public Intervention CreateIntervention(Intervention intervention)
        {
            _context.Interventions.Add(intervention);
            _context.SaveChanges();
            return intervention;
        }
        
        
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Rockets_Elevators_web_api
{
    public partial class Column
    {
        public long Id { get; set; }
        public string Types { get; set; } = null!;
        public string? Model { get; set; }
        public string NumberFloorServed { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string Information { get; set; } = null!;
        public string Notes { get; set; } = null!;
        public long? BatterieId { get; set; }
        [ForeignKey("BatterieId")]
        public Battery Battery { get; set; }
        
        public List<Elevator> Elevators { get; set;}
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rockets_Elevators_web_api
{
    public partial class Battery
    {
        public long Id { get; set; }
        public string Types { get; set; } = null!;
        public string Status { get; set; } = null!;
        public int EmployeeId { get; set; }
        public DateTime DateCommissioning { get; set; }
        public DateTime DateLastInspection { get; set; }
        public string CertificateOfOperations { get; set; } = null!;
        public string Information { get; set; } = null!;
        public string Notes { get; set; } = null!;
        public long? BuildingId { get; set; }
        [ForeignKey("BuildingId")]
        public Building Building { get; set; }
        public List<Column> Columns { get; set;}
        
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

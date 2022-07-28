using System;
using System.Collections.Generic;

namespace Rockets_Elevators_web_api
{
    public partial class Employee
    {
        public string FirstNname { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Title { get; set; } = null!;
        public long? UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

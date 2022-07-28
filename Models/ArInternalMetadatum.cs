using System;
using System.Collections.Generic;

namespace Rockets_Elevators_web_api
{
    public partial class ArInternalMetadatum
    {
        public string Key { get; set; } = null!;
        public string? Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

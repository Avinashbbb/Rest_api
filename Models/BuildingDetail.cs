﻿using System;
using System.Collections.Generic;

namespace Rockets_Elevators_web_api
{
    public partial class BuildingDetail
    {
        public long Id { get; set; }
        public int? BuildingId { get; set; }
        public string? InformationKey { get; set; }
        public string? Value { get; set; }
    }
}

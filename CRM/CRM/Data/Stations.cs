using System;
using System.Collections.Generic;

namespace CRM.Data
{
    public partial class Stations
    {
        public Stations()
        {
            Students = new HashSet<Students>();
        }

        public int StationId { get; set; }
        public string StationName { get; set; }
        public string StationDuty { get; set; }
        public string StationNeedTechnique { get; set; }

        public ICollection<Students> Students { get; set; }
    }
}

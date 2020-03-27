using System;
using System.Collections.Generic;

namespace CRM.Data
{
    public partial class SelectStationPeriods
    {
        public int SspId { get; set; }
        public int? SchoolId { get; set; }
        public int? SpecialtyId { get; set; }
        public DateTime SspPreachDate { get; set; }
        public byte SspOverDay { get; set; }

        public Schools School { get; set; }
        public Specialties Specialty { get; set; }
    }
}

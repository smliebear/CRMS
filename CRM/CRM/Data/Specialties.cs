using System;
using System.Collections.Generic;

namespace CRM.Data
{
    public partial class Specialties
    {
        public Specialties()
        {
            SchoolClasses = new HashSet<SchoolClasses>();
            SelectStationPeriods = new HashSet<SelectStationPeriods>();
        }

        public int SpecialtyId { get; set; }
        public string SpecialtyName { get; set; }
        public string SpecialtyDescription { get; set; }

        public ICollection<SchoolClasses> SchoolClasses { get; set; }
        public ICollection<SelectStationPeriods> SelectStationPeriods { get; set; }
    }
}

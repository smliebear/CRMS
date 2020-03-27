using System;
using System.Collections.Generic;

namespace CRM.Data
{
    public partial class Schools
    {
        public Schools()
        {
            SchoolClasses = new HashSet<SchoolClasses>();
            SelectStationPeriods = new HashSet<SelectStationPeriods>();
        }

        public int SchoolId { get; set; }
        public int? PId { get; set; }
        public string SchoolCode { get; set; }
        public string SchoolName { get; set; }
        public string SchoolRemark { get; set; }

        public Provinces P { get; set; }
        public ICollection<SchoolClasses> SchoolClasses { get; set; }
        public ICollection<SelectStationPeriods> SelectStationPeriods { get; set; }
    }
}

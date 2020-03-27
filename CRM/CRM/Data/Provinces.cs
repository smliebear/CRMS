using System;
using System.Collections.Generic;

namespace CRM.Data
{
    public partial class Provinces
    {
        public Provinces()
        {
            Schools = new HashSet<Schools>();
        }

        public int PId { get; set; }
        public string PName { get; set; }
        public string PRemark { get; set; }

        public ICollection<Schools> Schools { get; set; }
    }
}

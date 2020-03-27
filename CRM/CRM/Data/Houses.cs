using System;
using System.Collections.Generic;

namespace CRM.Data
{
    public partial class Houses
    {
        public Houses()
        {
            Floors = new HashSet<Floors>();
        }

        public int HId { get; set; }
        public string HName { get; set; }
        public string HRemark { get; set; }
        public byte? HMaleOrFemale { get; set; }

        public ICollection<Floors> Floors { get; set; }
    }
}

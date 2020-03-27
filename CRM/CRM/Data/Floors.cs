using System;
using System.Collections.Generic;

namespace CRM.Data
{
    public partial class Floors
    {
        public Floors()
        {
            Rooms = new HashSet<Rooms>();
        }

        public int FId { get; set; }
        public int? HId { get; set; }
        public string FName { get; set; }
        public string FRemark { get; set; }
        public byte? FMaleOrFemale { get; set; }

        public Houses H { get; set; }
        public ICollection<Rooms> Rooms { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CRM.Data
{
    public partial class RoomCategories
    {
        public RoomCategories()
        {
            Rooms = new HashSet<Rooms>();
        }

        public int RcId { get; set; }
        public string RcName { get; set; }
        public byte? RcCount { get; set; }
        public decimal? RcMoneyPerMonth { get; set; }

        public ICollection<Rooms> Rooms { get; set; }
    }
}

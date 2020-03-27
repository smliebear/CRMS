using System;
using System.Collections.Generic;

namespace CRM.Data
{
    public partial class Rooms
    {
        public int RId { get; set; }
        public int? FId { get; set; }
        public int? RcId { get; set; }
        public string RName { get; set; }
        public byte? RMaleOrFemale { get; set; }
        public bool? RIsHasFull { get; set; }

        public Floors F { get; set; }
        public RoomCategories Rc { get; set; }
    }
}

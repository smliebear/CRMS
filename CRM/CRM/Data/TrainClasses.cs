using System;
using System.Collections.Generic;

namespace CRM.Data
{
    public partial class TrainClasses
    {
        public int TcId { get; set; }
        public string TcName { get; set; }
        public string TcGrade { get; set; }
        public DateTime TcBeginTime { get; set; }
        public DateTime TcEndTime { get; set; }
        public byte TcMaxAmount { get; set; }
        public byte? TcMaleAmount { get; set; }
        public byte? TcFemaleAmount { get; set; }
        public byte? TcPeriod { get; set; }
    }
}

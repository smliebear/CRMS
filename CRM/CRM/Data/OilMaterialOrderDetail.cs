using System;
using System.Collections.Generic;

namespace CRM.Data
{
    public partial class OilMaterialOrderDetail
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public string OilSpec { get; set; }
        public decimal? Volume { get; set; }
        public decimal? Surplus { get; set; }
        public decimal? DayAvg { get; set; }
        public decimal? NeedAmount { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public bool? IsDel { get; set; }

        public OilMaterialOrder Order { get; set; }
    }
}

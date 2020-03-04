using System;
using System.Collections.Generic;

namespace CRM.Data
{
    public partial class OilMaterialOrder
    {
        public OilMaterialOrder()
        {
            OilMaterialOrderDetail = new HashSet<OilMaterialOrderDetail>();
        }

        public Guid Id { get; set; }
        public string No { get; set; }
        public Guid ApplyPersonId { get; set; }
        public DateTime? ApplyDate { get; set; }
        public string Remark { get; set; }
        public bool IsDel { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }

        public ICollection<OilMaterialOrderDetail> OilMaterialOrderDetail { get; set; }
    }
}

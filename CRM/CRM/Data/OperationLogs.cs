using System;
using System.Collections.Generic;

namespace CRM.Data
{
    public partial class OperationLogs
    {
        public int PlId { get; set; }
        public int? TId { get; set; }
        public string PlTableName { get; set; }
        public string PlOperation { get; set; }
        public string PlDescription { get; set; }
        public DateTime? PlTime { get; set; }

        public Teachers T { get; set; }
    }
}

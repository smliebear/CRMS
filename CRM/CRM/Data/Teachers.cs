using System;
using System.Collections.Generic;

namespace CRM.Data
{
    public partial class Teachers
    {
        public Teachers()
        {
            OperationLogs = new HashSet<OperationLogs>();
        }

        public int TId { get; set; }
        public string TName { get; set; }
        public string TSex { get; set; }
        public string TTel { get; set; }
        public byte TCategory { get; set; }
        public string TLoginName { get; set; }
        public string TPwd { get; set; }
        public byte TRole { get; set; }
        public bool TIsEnabled { get; set; }
        public DateTime? TLastLoginTime { get; set; }

        public ICollection<OperationLogs> OperationLogs { get; set; }
    }
}

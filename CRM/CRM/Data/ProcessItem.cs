using System;
using System.Collections.Generic;

namespace CRM.Data
{
    public partial class ProcessItem
    {
        public ProcessItem()
        {
            Approver = new HashSet<Approver>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Discrible { get; set; }

        public ICollection<Approver> Approver { get; set; }
    }
}

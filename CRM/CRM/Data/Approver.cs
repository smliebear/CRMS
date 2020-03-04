using System;
using System.Collections.Generic;

namespace CRM.Data
{
    public partial class Approver
    {
        public Guid Id { get; set; }
        public string JobCode { get; set; }
        public int AreaLeve { get; set; }
        public string Discrible { get; set; }
        public int Order { get; set; }
        public Guid? ProcessItemId { get; set; }
        public string ExecuteMethod { get; set; }

        public ProcessItem ProcessItem { get; set; }
    }
}

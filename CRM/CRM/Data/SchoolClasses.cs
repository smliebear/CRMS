using System;
using System.Collections.Generic;

namespace CRM.Data
{
    public partial class SchoolClasses
    {
        public SchoolClasses()
        {
            Students = new HashSet<Students>();
        }

        public int ScId { get; set; }
        public int? SchoolId { get; set; }
        public int? SpecialtyId { get; set; }
        public string ScName { get; set; }
        public int? ScFemaleAmount { get; set; }
        public int? ScMaleAmount { get; set; }
        public string ScTeacher { get; set; }
        public string ScSupervisor { get; set; }

        public Schools School { get; set; }
        public Specialties Specialty { get; set; }
        public ICollection<Students> Students { get; set; }
    }
}

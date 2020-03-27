using System;
using System.Collections.Generic;

namespace CRM.Data
{
    public partial class Students
    {
        public int StudentId { get; set; }
        public int? ScId { get; set; }
        public string StudentNo { get; set; }
        public string StudentName { get; set; }
        public string StudentNameSpell { get; set; }
        public string StudentSex { get; set; }
        public string StudentIdentityNumber { get; set; }
        public string StudentState { get; set; }
        public string StudentExam { get; set; }
        public string StudentEducation { get; set; }
        public string StudentSpecialty { get; set; }
        public string StudentSchoolofgraduation { get; set; }
        public string StudentPersonalTel { get; set; }
        public string StudentFamilyTel { get; set; }
        public string StudentQq { get; set; }
        public string StudentAddress { get; set; }
        public string StudentPostCode { get; set; }
        public string StudentEducationMoney { get; set; }
        public string StudentSkillTrainingMoney { get; set; }
        public string StudentTrainResideMoney { get; set; }
        public string StudentEvaluate1 { get; set; }
        public string StudentEvaluate2 { get; set; }
        public string StudentRemark { get; set; }
        public int? StationId { get; set; }
        public byte? StationtSelectStationCount { get; set; }

        public SchoolClasses Sc { get; set; }
        public Stations Station { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace berkeley_college.Models
{
    public partial class Module
    {
        public Module()
        {
            Assignment = new HashSet<Assignment>();
            ModuleStudent = new HashSet<ModuleStudent>();
            StudentAttendenceInfo = new HashSet<StudentAttendenceInfo>();
            TeacherModuleInfo = new HashSet<TeacherModuleInfo>();
        }

        public string ModuleId { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }
        public decimal ModuleTeachingDays { get; set; }
        public decimal ModuleCredit { get; set; }

        public virtual ICollection<Assignment> Assignment { get; set; }
        public virtual ICollection<ModuleStudent> ModuleStudent { get; set; }
        public virtual ICollection<StudentAttendenceInfo> StudentAttendenceInfo { get; set; }
        public virtual ICollection<TeacherModuleInfo> TeacherModuleInfo { get; set; }
    }
}

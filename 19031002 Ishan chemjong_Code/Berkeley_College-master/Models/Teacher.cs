using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace berkeley_college.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            TeacherModuleInfo = new HashSet<TeacherModuleInfo>();
            Modules = new HashSet<Module>();
        }

        public string TeacherType { get; set; }
        public decimal Salary { get; set; }
        public string PersonId { get; set; }

        public virtual Person Person { get; set; }
        [NotMapped]
        public virtual ICollection<Module> Modules { get; set; }
        public virtual ICollection<TeacherModuleInfo> TeacherModuleInfo { get; set; }
    }
}

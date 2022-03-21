using System;
using System.Collections.Generic;

namespace berkeley_college.Models
{
    public partial class ModuleStudent
    {
        public string ModuleId { get; set; }
        public string StudentId { get; set; }

        public virtual Module Module { get; set; }
        public virtual Student Student { get; set; }
    }
}

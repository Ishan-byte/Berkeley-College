using System;
using System.Collections.Generic;

namespace berkeley_college.Models
{
    public partial class Assignment
    {
        public Assignment()
        {
            ResultInfo = new HashSet<ResultInfo>();
        }

        public string AssignmentId { get; set; }
        public string AssignmentType { get; set; }
        public string DepartmentId { get; set; }
        public string ModuleId { get; set; }

        public virtual Departments Department { get; set; }
        public virtual Module Module { get; set; }
        public virtual ICollection<ResultInfo> ResultInfo { get; set; }
    }
}

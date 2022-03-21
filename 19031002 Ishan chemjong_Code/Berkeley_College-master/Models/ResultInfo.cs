using System;
using System.Collections.Generic;

namespace berkeley_college.Models
{
    public partial class ResultInfo
    {
        public string ResultId { get; set; }
        public string AssignmentId { get; set; }
        public string Grade { get; set; }
        public string Status { get; set; }
        public string StudentId { get; set; }

        public virtual Assignment Assignment { get; set; }

        public virtual Student Student { get; set; }
    }
}

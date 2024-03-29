﻿using System;
using System.Collections.Generic;

namespace berkeley_college.Models
{
    public partial class StudentAttendenceInfo
    {
        public string StudentId { get; set; }
        public string ModuleId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string DepartmentId { get; set; }

        public virtual Departments Department { get; set; }
        public virtual Module Module { get; set; }
        public virtual Student Student { get; set; }
    }
}

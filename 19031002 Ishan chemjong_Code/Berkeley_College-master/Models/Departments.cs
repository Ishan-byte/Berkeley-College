using System;
using System.Collections.Generic;

namespace berkeley_college.Models
{
    public partial class Departments
    {
        public Departments()
        {
            Assignment = new HashSet<Assignment>();
            StudentAttendenceInfo = new HashSet<StudentAttendenceInfo>();
            StudentFeePayment = new HashSet<StudentFeePayment>();
        }

        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<Assignment> Assignment { get; set; }
        public virtual ICollection<StudentAttendenceInfo> StudentAttendenceInfo { get; set; }
        public virtual ICollection<StudentFeePayment> StudentFeePayment { get; set; }
    }
}

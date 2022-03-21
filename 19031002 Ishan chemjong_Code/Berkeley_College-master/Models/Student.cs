using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace berkeley_college.Models
{
    public partial class Student
    {
        public Student()
        {
            ModuleStudent = new HashSet<ModuleStudent>();
            ResultInfo = new HashSet<ResultInfo>();
            StudentAttendenceInfo = new HashSet<StudentAttendenceInfo>();
            StudentFeePayment = new HashSet<StudentFeePayment>();
            Assignments = new HashSet<Assignment>();
        }

        public string PersonId { get; set; }
        public decimal StudentYear { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<ModuleStudent> ModuleStudent { get; set; }
        public virtual ICollection<ResultInfo> ResultInfo { get; set; }
        public virtual ICollection<StudentAttendenceInfo> StudentAttendenceInfo { get; set; }
        public virtual ICollection<StudentFeePayment> StudentFeePayment { get; set; }
        [NotMapped]
        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}

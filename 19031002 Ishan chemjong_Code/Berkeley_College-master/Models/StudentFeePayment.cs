using System;
using System.Collections.Generic;

namespace berkeley_college.Models
{
    public partial class StudentFeePayment
    {
        public string PaymentId { get; set; }
        public decimal Amount { get; set; }
        public decimal Year { get; set; }
        public DateTime PaymentDate { get; set; }
        public string StudentId { get; set; }
        public string DepartmentId { get; set; }

        public virtual Departments Department { get; set; }
        public virtual Student Student { get; set; }
    }
}

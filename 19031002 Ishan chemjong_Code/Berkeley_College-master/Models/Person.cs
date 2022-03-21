using System;
using System.Collections.Generic;

namespace berkeley_college.Models
{
    public partial class Person
    {
        public Person()
        {
            PersonAddressInfo = new HashSet<PersonAddressInfo>();
        }

        public string PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }

        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<PersonAddressInfo> PersonAddressInfo { get; set; }
    }
}

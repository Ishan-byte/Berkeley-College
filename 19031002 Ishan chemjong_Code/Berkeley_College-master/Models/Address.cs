using System;
using System.Collections.Generic;

namespace berkeley_college.Models
{
    public partial class Address
    {
        public Address()
        {
            PersonAddressInfo = new HashSet<PersonAddressInfo>();
        }

        public string AddressId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public decimal PostalCode { get; set; }

        public virtual ICollection<PersonAddressInfo> PersonAddressInfo { get; set; }
    }
}

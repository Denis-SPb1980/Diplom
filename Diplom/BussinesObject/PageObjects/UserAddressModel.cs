using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.BussinesObject.PageObjects
{
    public class UserAddressModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string MobilePhone { get; set; }
        public string AddressAlias { get; set; }
    }
}

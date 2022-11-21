using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sbas_homework_28_Entity_Framework
{
    internal class Customer
    {
        public Guid CustomersId { get; set; }
        public string FirstName { get; set; }
        public string LasttName { get; set; }
        public int CustomersPhoneNuber { get; set; }
    }
}

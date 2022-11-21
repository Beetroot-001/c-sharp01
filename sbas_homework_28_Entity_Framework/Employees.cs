using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sbas_homework_28_Entity_Framework
{
    internal class Employees
    {
        public Guid EmployeesId { get; set; }
        public string FirstName { get; set; }
        public string LasttName { get; set; }
        public float EmployeesPhoneNuber { get; set; }
    }
}

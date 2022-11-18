using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public ICollection<Product> Products { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Column(TypeName = "Date")]
        public DateTime SendDate { get; set; }

        #region Audit
        [Column(TypeName = "Date")]
        public DateTime PostDate { get; set; }
        #endregion
    }
}

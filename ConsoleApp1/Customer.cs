using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Customer
    {   
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Rating { get; set; }
        public ICollection<Order>? OrderId { get; set;}

        #region Audit
        [Column(TypeName = "Date")]
        public DateTime RegisterDate { get; set; }
        #endregion
    }
}

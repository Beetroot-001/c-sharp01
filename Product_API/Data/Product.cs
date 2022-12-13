using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace Product_API.Data
{
    public class Product
    {

        [Key]//data anotation
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Unicode]
        public string Taytle { get; set; }

        [Unicode]
        public String Producer { get; set; }

        public float Priсe { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        //public ICollection<Feedback> feedbacks { get; set; }

        }
}

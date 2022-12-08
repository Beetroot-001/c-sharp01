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

        [Required]//not null
        [Unicode]
        public string Taytle { get; set; }

        [Required]
        [Unicode]
        public String Producer { get; set; }

        [Required]
        public float Priсe { get; set; }

        [Required]
        public int Quantity { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

       // public ICollection<Feedback> feedbacks { get; set; }

    }
}

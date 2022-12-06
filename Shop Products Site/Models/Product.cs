using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop_Products_Site.Models
{
    public class Product
    {
        [Key]//data anotation
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Required]//not null
        public string Taytle { get; set; }

        [Required]
        public int Producer { get; set; }

        [Required]
        public int Priсe { get; set; }

        [Required]
        public int Quantity { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public ICollection Feedback { get; set; }
    }
}

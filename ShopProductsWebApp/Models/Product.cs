using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopProductsWebApp.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Title { get; set; }
        [Required]
        public string Type { get; set; }

        [DefaultValue(0.0f)]
        public float Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string? Description { get; set; }

    }
}

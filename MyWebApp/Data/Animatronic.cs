using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyWebApp.Data
{
    public class Animatronic
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [MaxLength(10)]
        public string StageNickname { get; set; }
        [DefaultValue(false)]
        public bool IsBroken { get; set; }
        [Required]
        public string StagePrescription { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }

    }
}

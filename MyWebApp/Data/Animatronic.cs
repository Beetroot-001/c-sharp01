using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyWebApp.Data
{
    public class Animatronic
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string StageNickname { get; set; }
        [DefaultValue(false)]
        public bool IsBroken { get; set; }
        public string StagePrescription { get; set; }
        public string? Description { get; set; }

    }
}

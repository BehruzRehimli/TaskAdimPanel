using System.ComponentModel.DataAnnotations;

namespace HomeworkPustok.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Title1 { get; set; }
        [Required]
        [MaxLength(30)]
        public string Title2 { get; set; }
        public string Image { get; set; }
        [Required]
        [MaxLength(50)]
        public string Des { get; set; }

        public byte SlideLocation { get; set; }


    }
}

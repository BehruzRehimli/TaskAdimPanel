
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeworkPustok.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string Title { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }
        public byte Discount { get; set; } = 0;
        public bool Availability { get; set; } = true;
        public int RewardPoint { get; set; }
        [Required]
        public string Desc { get; set; }
        public List<BookImage> Images { get; set; }
        public Author Author { get; set; }
        public Genre Genre { get; set; }

        public bool IsFeature { get; set; } = false;
        public List<BookTag> BookTag { get; set; }
    }
}

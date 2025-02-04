using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KandyKaffe.Service.ProductAPI.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [Range(1,1000)]
        public double Price { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        // Foreign key from Category API
        public int CategoryId { get; set; }
        public string ImageUrl { get; set; }

        public bool IsActive { get; set; }
    }
}

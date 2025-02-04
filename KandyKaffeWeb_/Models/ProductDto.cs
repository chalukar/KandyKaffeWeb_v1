

using System.ComponentModel.DataAnnotations;

namespace KandyKaffeWeb_.Models

{
    public class ProductDto
    {
        public int ProductId { get; set; }
        [MaxLength(100, ErrorMessage = "Product name cannot exceed 100 characters.")]
        public string Name { get; set; }
        [Range(1, 1000, ErrorMessage = "Price must be between 1 and 1000.")]
        public double Price { get; set; }
        [MaxLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Please confirm if the product is active.")]
        public bool IsActive { get; set; }
    }
}

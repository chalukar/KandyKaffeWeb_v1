using System.ComponentModel.DataAnnotations;

namespace KandyKaffe.Service.CategoryAPI.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string CategoryCode { get; set; }
        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

    }
}

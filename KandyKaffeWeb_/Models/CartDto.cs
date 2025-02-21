using System.ComponentModel.DataAnnotations;

namespace KandyKaffeWeb_.Models
{
    public class CartDto
    {
        public CartHeaderDto CartHeader { get; set; }
        public IEnumerable<CartDetailsDto?> CartDetails { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Application.Abstraction.Models.Product
{
    public class UpdateProductDto
    {
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }
        [Required]
        [Range(0.01,double.MaxValue)]
        public decimal Price { get; set; }
        [Range(0,int.MaxValue)]
        public int Stock { get; set; }
    }
}

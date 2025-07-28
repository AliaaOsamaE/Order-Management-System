using System.ComponentModel.DataAnnotations;

namespace Application.Abstraction.Models.Product
{
    public class ProductToReturnDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}

using Application.Abstraction.Models.OrderDtos;
using System.ComponentModel.DataAnnotations;

namespace Application.Abstraction.Models._NewFolder
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public required string Email { get; set; }

        public List<OrderDto>? Orders { get; set; }
    }
}

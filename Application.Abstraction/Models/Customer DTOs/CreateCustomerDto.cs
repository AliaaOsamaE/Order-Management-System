using System.ComponentModel.DataAnnotations;

namespace Application.Abstraction.Models.Customer_DTOs
{
    public class CreateCustomerDto
    {
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; } 

        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public required string Email { get; set; }
    }
}

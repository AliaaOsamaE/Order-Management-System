using Domain.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace Application.Abstraction.Models.User
{
    public class RegisterUserDto
    {
        [Required]
        [MaxLength(50)]
        public required string Username { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Password { get; set; } 

        [Required]
        public Role Role { get; set; }
    }


}

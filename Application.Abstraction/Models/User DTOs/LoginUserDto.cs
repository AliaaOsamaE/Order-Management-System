using System.ComponentModel.DataAnnotations;

namespace Application.Abstraction.Models.User
{
    public class LoginUserDto
    {
        [Required]
        [MaxLength(50)]
        public required string Username { get; set; } 

        [Required]
        [MaxLength(100)]
        public required string Password { get; set; }
    }

}

using System.ComponentModel.DataAnnotations;

namespace Application.Abstraction.Models.User
{
    public class LoginDto
    {

        public required string Username { get; set; } 
        public required string Password { get; set; }
    }

}

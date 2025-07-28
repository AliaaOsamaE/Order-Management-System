using Domain.Entities.Users;

namespace Application.Abstraction.Models.User
{
    public class UserToReturnDto
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public Role Role { get; set; }
    }
}

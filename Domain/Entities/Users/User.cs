using Domain.Common;

namespace Domain.Entities.Users
{
    public enum Role
    {
        Admin,
        Customer
    }

    public class User : BaseEntity<int>
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public Role Role { get; set; }
    }
}

    
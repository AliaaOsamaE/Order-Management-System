using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Users
{
    public class User : BaseEntity<int>
    {
        public required string Name { get; set; } 
        public required string Email { get; set; }
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}

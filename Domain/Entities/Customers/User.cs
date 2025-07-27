using Domain.Common;

namespace Domain.Entities.Customers
{
    public class Customer : BaseEntity<int>
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}

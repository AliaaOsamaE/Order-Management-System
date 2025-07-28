using Domain.Entities.Orders;
using System.ComponentModel.DataAnnotations;

namespace Application.Abstraction.Models.OrderDto
{
    public class UpdateOrderStatusDto
    {
        [Required]
        public OrderStatus Status { get; set; }
    }

}

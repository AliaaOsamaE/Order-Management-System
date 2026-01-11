using Domain.Entities.Orders;
using System.ComponentModel.DataAnnotations;

namespace Application.Abstraction.Models.OrderDtos
{
    public class UpdateOrderStatusDto
    {
        [Required]
        public OrderStatus Status { get; set; }
    }

}

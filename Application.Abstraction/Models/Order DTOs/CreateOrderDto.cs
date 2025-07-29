using Application.Abstraction.Models.OrderItemsDto.Application.Abstraction.Models.OrderItemsDto;
using Domain.Entities.Orders;
using System.ComponentModel.DataAnnotations;

namespace Application.Abstraction.Models.OrderDtos
{
    public class CreateOrderDto
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public PaymentMethod PaymentMethod { get; set; }

        [Required]
        public List<CreateOrderItemDto> OrderItems { get; set; } = new List<CreateOrderItemDto>();

    }

}

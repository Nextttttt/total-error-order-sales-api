using System;
using System.Threading.Tasks;
using TotalError.OrderSales.Domain.Abstractions.Repositories;
using TotalError.OrderSales.Domain.Abstractions.Services;
using TotalError.OrderSales.Domain.Dtos;

namespace TotalError.OrderSales.Services
{
    public class OrderService : BaseService<OrderDto>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
            :base(orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public override Task<OrderDto> CreateAsync(OrderDto dto)
        {
            return base.CreateAsync(dto);
        }

        public override Task<OrderDto> GetByIdAsync(Guid id)
        {
            return base.GetByIdAsync(id);
        }

        public override Task UpdateAsync(OrderDto dto)
        {
            return base.UpdateAsync(dto);
        }

        public override Task DeleteAsync(Guid id)
        {
            return base.DeleteAsync(id);
        }
    }
}

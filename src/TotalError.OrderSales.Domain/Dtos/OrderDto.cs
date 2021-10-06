using System;

namespace TotalError.OrderSales.Domain.Dtos
{
    public class OrderDto : BaseDto
    {
        public Guid OrderId { get; set; }

        public CountryDto Country { get; set; }

        public DateTime Date { get; set; }

        public SaleDto Sale { get; set; }

    }
}

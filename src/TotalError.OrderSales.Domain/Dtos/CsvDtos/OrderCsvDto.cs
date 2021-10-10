using System;
using TotalError.OrderSales.Domain.Enums;

namespace TotalError.OrderSales.Domain.Dtos
{
    public class OrderCsvDto : BaseDto
    {
        public Guid OrderId { get; set; }

        public SalesChannel SaleChannel { get; set; }

        public OrderPriority OrderPriority { get; set; }

        public CountryCsvDto Country { get; set; }

        public DateTime Date { get; set; }

        public SaleCsvDto Sale { get; set; }

    }
}

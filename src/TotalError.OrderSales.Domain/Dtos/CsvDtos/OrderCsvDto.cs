using System;

namespace TotalError.OrderSales.Domain.Dtos
{
    public class OrderCsvDto : BaseDto
    {
        public string OrderId { get; set; }

        public string SalesChannel { get; set; }

        public string OrderPriority { get; set; }

        public CountryCsvDto Country { get; set; }

        public DateTime Date { get; set; }

        public SaleCsvDto Sale { get; set; }

    }
}

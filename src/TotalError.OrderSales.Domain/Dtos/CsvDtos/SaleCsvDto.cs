using System;

namespace TotalError.OrderSales.Domain.Dtos
{
    public class SaleCsvDto : BaseDto
    {
        public DateTime  ShipDate { get; set; }

        public ItemCsvDto Item { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal TotalRevenue { get; set; }

        public decimal TotalCost { get; set; }

        public decimal TotalProfit { get; set; }
    }
}

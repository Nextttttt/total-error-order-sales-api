using System;

namespace TotalError.OrderSales.Domain.Dtos
{
    public class SaleDto : BaseDto
    {
        public DateTime ShipDate { get; set; }

        public string ItemType { get; set; }

        public Guid ItemId { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal TotalRevenue { get; set; }

        public decimal TotalCost { get; set; }

        public decimal TotalProfit { get; set; }
    }
}

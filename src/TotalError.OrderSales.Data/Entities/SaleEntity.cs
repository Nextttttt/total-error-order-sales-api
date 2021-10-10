using System;
using System.ComponentModel.DataAnnotations;

namespace TotalError.OrderSales.Data.Entities
{
    public class SaleEntity : BaseEntity
    {
        [Required]
        public DateTime ShipDate { get; set; }

        [Required]
        public Guid ItemId { get; set; }

        [Required]
        public ItemEntity Item { get; set; }

        [Required]
        public int UnitsSold { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public decimal TotalRevenue { get; set; }

        [Required]
        public decimal TotalCost { get; set; }

        [Required]
        public decimal TotalProfit { get; set; }

    }
}

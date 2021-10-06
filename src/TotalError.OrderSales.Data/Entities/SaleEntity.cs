using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalError.OrderSales.Data.Entities
{
    public class SaleEntity : BaseEntity
    {
        public DateTime ShipDate { get; set; }

        public Guid ItemId { get; set; }

        public ItemEntity Item { get; set; }

        public int UnitsSold { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalRevenue { get; set; }

        public decimal TotalCost { get; set; }

        public decimal TotalProfit { get; set; }

    }
}

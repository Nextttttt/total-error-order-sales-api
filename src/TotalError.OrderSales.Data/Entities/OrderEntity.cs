using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalError.OrderSales.Domain.Enums;

namespace TotalError.OrderSales.Data.Entities
{
    public class OrderEntity : BaseEntity
    {
        public SalesChannel SalesChannel { get; set; }

        public OrderPriority OrderPriority { get; set; }

        public DateTime OrderDate { get; set; }

        public Guid RegionId { get; set; }

        public RegionEntity Region { get; set; }

        public Guid CountryId { get; set; }

        public CountryEntity Country { get; set; }

        public Guid SaleId { get; set; }

        public SaleEntity Sale { get; set; }
    }
}

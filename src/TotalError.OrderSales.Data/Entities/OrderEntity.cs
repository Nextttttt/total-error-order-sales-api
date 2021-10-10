using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalError.OrderSales.Domain.Enums;

namespace TotalError.OrderSales.Data.Entities
{
    public class OrderEntity : BaseEntity
    {
        [Required]
        [EnumDataType(typeof(SalesChannel))]
        public SalesChannel SalesChannel { get; set; }

        [Required]
        [EnumDataType(typeof(OrderPriority))]
        public OrderPriority OrderPriority { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public Guid RegionId { get; set; }

        [Required]
        public RegionEntity Region { get; set; }

        [Required]
        public Guid CountryId { get; set; }

        [Required]
        public CountryEntity Country { get; set; }

        [Required]
        public Guid SaleId { get; set; }

        [Required]
        public SaleEntity Sale { get; set; }
    }
}

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
        [MaxLength(20)]
        public string OrderId { get; set; }
        [Required]
        [MaxLength(10)]
        public string SalesChannel { get; set; }

        [Required]
        [MaxLength(5)]
        public string OrderPriority { get; set; }

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

        public DateTime CreatedOn { get; set; }
    }
}

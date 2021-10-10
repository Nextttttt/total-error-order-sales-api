using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TotalError.OrderSales.Data.Entities
{
    public class RegionEntity : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public List<OrderEntity> Orders { get; set; }

        public List<CountryEntity> Countries { get; set; }
    }
}

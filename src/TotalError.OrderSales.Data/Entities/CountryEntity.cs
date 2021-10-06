using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalError.OrderSales.Data.Entities
{
    public class CountryEntity : BaseEntity
    {
        public string Name { get; set; }

        public Guid RegionId { get; set; }

        public RegionEntity Region { get; set; }
    }
}

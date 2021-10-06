using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalError.OrderSales.Data.Entities
{
    public class RegionEntity : BaseEntity
    {
        public string Name { get; set; }

        public List<OrderEntity> Orders { get; set; }

        public List<CountryEntity> Countries { get; set; }
    }
}

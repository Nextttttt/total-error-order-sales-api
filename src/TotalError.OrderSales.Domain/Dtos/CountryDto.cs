using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalError.OrderSales.Domain.Dtos
{
    public class CountryDto : BaseDto
    {
        public string Name { get; set; }

        public string RegionName { get; set; }

        public Guid RegionId { get; set; }
    }
}

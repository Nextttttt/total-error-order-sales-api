using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalError.OrderSales.Domain.Dtos
{
    public class ItemDto : BaseDto
    {
        public string ItemType { get; set; }
        public decimal Cost { get; set; }
    }
}

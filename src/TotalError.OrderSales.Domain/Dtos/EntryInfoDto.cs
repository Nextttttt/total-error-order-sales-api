using System;
using System.Collections.Generic;

namespace TotalError.OrderSales.Domain.Dtos
{
    public class EntryInfoDto
    {
        public OrderCsvDto Record { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}

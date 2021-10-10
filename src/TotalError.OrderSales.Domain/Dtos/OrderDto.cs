﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalError.OrderSales.Domain.Enums;

namespace TotalError.OrderSales.Domain.Dtos
{
    public class OrderDto : BaseDto
    {
        public Guid OrderId { get; set; }

        public SalesChannel SaleChannel { get; set; }

        public OrderPriority OrderPriority { get; set; }

        public Guid CountryId { get; set; }

        public DateTime Date { get; set; }

        public Guid SaleId { get; set; }
    }
}

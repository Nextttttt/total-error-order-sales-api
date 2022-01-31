﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalError.OrderSales.Domain.Dtos
{
    public class OrderSummeryDto
    {
        public List<OrderDto> Orders { get; set; }

        public decimal TotalCosts { get; set; }

        public decimal TotalProfits { get; set; }
    }
}

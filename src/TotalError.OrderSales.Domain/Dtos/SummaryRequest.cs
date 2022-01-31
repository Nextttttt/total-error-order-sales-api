using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalError.OrderSales.Domain.Dtos
{
    public class SummaryRequest
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public bool GetTotalCosts { get; set; }

        public bool GetTotalProfits { get; set; }
    }
}

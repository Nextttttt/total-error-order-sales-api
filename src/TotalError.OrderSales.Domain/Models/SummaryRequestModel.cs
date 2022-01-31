using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalError.OrderSales.Domain.Models
{
    public class SummaryRequestModel
    {
        public string name { get; set; }

        public DateTime Date { get; set; }

        public bool GetTotalCosts { get; set; }

        public bool GetTotalProfits { get; set; }
    }
}

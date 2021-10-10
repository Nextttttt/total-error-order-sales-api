using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalError.OrderSales.Data.Entities
{
    public class ItemEntity : BaseEntity
    {
        [Required]
        public string ItemType { get; set; }

        [Required]
        public decimal UnitCost { get; set; }

        public List<SaleEntity> Sales { get; set; }
    }
}

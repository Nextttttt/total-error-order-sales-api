using System;
using System.ComponentModel.DataAnnotations;

namespace TotalError.OrderSales.Data.Entities
{
    public class BaseEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
    }
}

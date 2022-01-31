using System;
using AutoMapper;

namespace TotalError.OrderSales.Domain.Dtos
{
    public class OrderDto : BaseDto
    {
        public string OrderId { get; set; }

        public string SalesChannel { get; set; }

        public string OrderPriority { get; set; }

        public string CountryName { get; set; }

        public Guid CountryId { get; set; }

        public string RegionName { get; set; }

        public Guid RegionId { get; set; }

        public DateTime Date { get; set; }

        public Guid SaleId { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}

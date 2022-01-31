using CsvHelper.Configuration;
using TotalError.OrderSales.Domain.Dtos;

namespace TotalError.OrderSales.Domain
{
    public sealed class OrderCsvMap : ClassMap<OrderCsvDto>
    {
        public OrderCsvMap()
        {
            Map(m => m.OrderPriority).Name("Order Priority");
            Map(m => m.SalesChannel).Name("Sales Channel");
            Map(m => m.Country.Name).Name("Country");
            Map(m => m.Country.Region.Name).Name("Region");
            Map(m => m.Sale.Item.ItemType).Name("Item Type");
            Map(m => m.Date).Name("Order Date");
            Map(m => m.OrderId).Name("Order ID");
            Map(m => m.Sale.ShipDate).Name("Ship Date");
            Map(m => m.Sale.Quantity).Name("Units Sold");
            Map(m => m.Sale.Price).Name("Unit Price");
            Map(m => m.Sale.Item.Cost).Name("Unit Cost");
            Map(m => m.Sale.TotalRevenue).Name("Total Revenue");
            Map(m => m.Sale.TotalCost).Name("Total Cost");
            Map(m => m.Sale.TotalProfit).Name("Total Profit");
        }
    }
}

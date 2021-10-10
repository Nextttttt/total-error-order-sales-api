namespace TotalError.OrderSales.Domain.Dtos
{
    public class ItemDto : BaseDto
    {
        public string ItemType { get; set; }
        public decimal Cost { get; set; }
    }
}

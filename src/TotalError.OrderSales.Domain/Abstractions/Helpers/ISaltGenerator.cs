namespace TotalError.OrderSales.Domain.Abstractions.Helpers
{
    public interface ISaltGenerator
    {
        byte[] GenerateSalt();
    }
}

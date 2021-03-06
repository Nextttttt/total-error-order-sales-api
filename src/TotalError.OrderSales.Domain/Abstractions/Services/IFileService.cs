using System.Collections.Generic;
using System.Threading.Tasks;
using TotalError.OrderSales.Domain.Dtos;

namespace TotalError.OrderSales.Domain.Abstractions.Services
{
    public interface IFileService
    {
        Task ReadFile(string directory);
    }
}

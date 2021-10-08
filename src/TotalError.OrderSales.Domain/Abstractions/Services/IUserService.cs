using System.Threading.Tasks;
using TotalError.OrderSales.Domain.Dtos;

namespace TotalError.OrderSales.Domain.Abstractions.Services
{
    public interface IUserService : IBaseService<UserDto>
    {
        public Task<LoginResponseDto> LoginAsync(string email, string password);
    }
}

using System.Threading.Tasks;
using TotalError.OrderSales.Domain.Dtos;

namespace TotalError.OrderSales.Domain.Abstractions.Repositories
{
    public interface IUserRepository : IBaseRepository<UserDto>
    {
        public Task<UserDto> GetByEmailAsync(string email);
    }
}

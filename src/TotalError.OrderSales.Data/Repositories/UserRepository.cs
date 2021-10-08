using AutoMapper;
using System.Threading.Tasks;
using TotalError.OrderSales.Data.Entities;
using TotalError.OrderSales.Domain.Abstractions.Repositories;
using TotalError.OrderSales.Domain.Dtos;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TotalError.OrderSales.Data.Repositories
{
    public class UserRepository : BaseRepository<UserDto,UserEntity>, IUserRepository
    {
        public UserRepository(TotalErrorDbContext dbContext, IMapper mapper)
            :base(dbContext,mapper)
        {

        }

        public async Task<UserDto> GetByEmailAsync(string email)
        {
            var dto = await _dbContext.Users.Where(u => u.Email == email).FirstOrDefaultAsync();

            return _mapper.Map<UserDto>(dto);
        }
    }
}

using System.Threading.Tasks;
using TotalError.OrderSales.Domain.Abstractions.Helpers;
using TotalError.OrderSales.Domain.Abstractions.Repositories;
using TotalError.OrderSales.Domain.Abstractions.Services;
using TotalError.OrderSales.Domain.Constants;
using TotalError.OrderSales.Domain.Dtos;
using TotalError.OrderSales.Domain.Exceptions;

namespace TotalError.OrderSales.Services
{
    public class UserService : BaseService<UserDto>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;
        private readonly IHasherService _hasher;

        public UserService(IUserRepository userRepository, IHasherService hasher, IJwtService jwtService)
            :base(userRepository)
        {
            _jwtService = jwtService;
            _userRepository = userRepository;
            _hasher = hasher;
        }

        public override async Task<UserDto> CreateAsync(UserDto dto)
        {
            if (await _userRepository.GetByEmailAsync(dto.Email) != null)
            {
                throw new AppException(StringConstants.UserExists);
            }

            var passAndSalt = _hasher.HashPassword(dto.Password);
            dto.Password = passAndSalt.Password;
            dto.Salt = passAndSalt.Salt;
            dto.Email = dto.Email.ToLower();

            return await _userRepository.CreateAsync(dto);
        }

        public async Task<LoginResponseDto> LoginAsync(string email, string password)
        {
            UserDto user = await _userRepository.GetByEmailAsync(email);
            if (user == null || !_hasher.VerifyHashedPassword(password, user.Password, user.Salt))
            {
                throw new AppException(StringConstants.InvalidUserOrPass);
            }
            var token = _jwtService.GenerateJsonWebToken(user.Role, user.Id);

            return new LoginResponseDto
            {
                JwtToken = token
            };
        }
    }
}

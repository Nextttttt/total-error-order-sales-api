using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TotalError.OrderSales.Api.Models;
using TotalError.OrderSales.Domain.Abstractions.Services;
using TotalError.OrderSales.Domain.Dtos;

namespace TotalError.OrderSales.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public AuthController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model)
        {
            var dto = _mapper.Map<UserDto>(model);

            await _userService.CreateAsync(dto);

            return CreatedAtRoute("Login", model);
        }
        [HttpPost("login", Name = "Login")]
        [ProducesResponseType(typeof(LoginResponseDto),StatusCodes.Status200OK)]
        public async Task<IActionResult> LoginAcync([FromBody] LoginModel login)
        {
            var dto = await _userService.LoginAsync(login.Email, login.Password);
            return Ok(_mapper.Map<LoginResponseDto>(dto));
        }
    }
}

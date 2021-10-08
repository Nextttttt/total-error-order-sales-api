using TotalError.OrderSales.Domain.Enums;

namespace TotalError.OrderSales.Domain.Dtos
{
    public class UserDto : BaseDto
    {
        public string Name { get; set; }
        
        public string Email { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }

        public string Salt { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace TotalError.OrderSales.Data.Entities
{
    public class UserEntity : BaseEntity
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        public string Salt { get; set; }
    }
}

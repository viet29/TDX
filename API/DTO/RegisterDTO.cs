using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class RegisterDTO
    {
        [Required]
        [StringLength(32, MinimumLength = 6)]
        public string Username { get; set; }

        [Required]
        [StringLength(128, MinimumLength = 8)]
        public string Password { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace OperatorDashboard.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(9, ErrorMessage="You must specify password")]
        public string Password { get; set; }
    }
}
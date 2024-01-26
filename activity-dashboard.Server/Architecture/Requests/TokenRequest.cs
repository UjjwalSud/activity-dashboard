using System.ComponentModel.DataAnnotations;

namespace activity_dashboard.Server.Architecture.Requests
{
    public class TokenRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Todo.Api.Models
{
    public class Login
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}

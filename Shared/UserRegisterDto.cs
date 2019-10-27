using System.ComponentModel.DataAnnotations;

namespace FreeBnB.Shared
{
  public class UserRegisterDto
  {
    [Required]
    public string Username { get; set; }

    [Required]
    [StringLength(8, MinimumLength = 4, ErrorMessage = "Must specify a password between 4 and 8 characters.")]
    public string Password { get; set; }
  }
}

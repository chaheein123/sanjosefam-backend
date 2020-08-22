using System;
using System.ComponentModel.DataAnnotations;

namespace sanjosefam_backend.Dtos.UserDto
{
  public class UserRegisterDto
  {
    [Required]
    [MaxLength(25)]
    [MinLength(3)]
    public string UserName { get; set; }

    [Required]
    [MaxLength(320)]
    [MinLength(7)]
    public string UserEmail { get; set; }

    [Required]
    [MaxLength(25)]
    [MinLength(6)]
    public string UserPw { get; set; }

  }
}

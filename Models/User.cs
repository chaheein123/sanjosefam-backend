using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sanjosefam_backend.Models
{
  public class User
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(20)]
    [MinLength(4)]
    public string UserName { get; set; }

    [Required]
    [MaxLength(320)]
    [MinLength(7)]
    public string UserEmail { get; set; }

    [Required]
    public byte[] PasswordHash { get; set; }

    [Required]
    public byte[] PasswordSalt { get; set; }

    [MaxLength(40)]
    public string UserJob { get; set; }

    [MaxLength(40)]
    public string UserRealName { get; set; }

    [MaxLength(200)]
    public string UserIntro { get; set; }

    public string UserImg { get; set; }

    // Posts of the users (one to many relationship)
    public List<Post> Posts { get; set; }

  }
}

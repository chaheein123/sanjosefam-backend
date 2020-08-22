using System;
using System.ComponentModel.DataAnnotations;

namespace sanjosefam_backend.Models
{
  public class User
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(25)]
    [MinLength(3)]
    public string UserName { get; set; }

    [Required]
    [MaxLength(320)]
    [MinLength(7)]
    public string UserEmail { get; set; }

    [Required]
    public byte[] PasswordHash { get; set; }

    [Required]
    public byte[] PasswordSalt { get; set; }


    //public string ImgUrl { get; set; }

    //public string UserImg { get; set; }

  }
}

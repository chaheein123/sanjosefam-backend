using System;
using System.ComponentModel.DataAnnotations;

namespace sanjosefam_backend.Models
{
  public class Post
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(3200)]
    public string Content { get; set; }

    // Each post belongs to a user (one to many relationship)
    public User User { get; set; }

  }
}

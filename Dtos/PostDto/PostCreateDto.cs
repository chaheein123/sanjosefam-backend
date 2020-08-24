using System;
using System.ComponentModel.DataAnnotations;

namespace sanjosefam_backend.Dtos.PostDto
{
  public class PostCreateDto
  {
    [Required]
    [MaxLength(3200)]
    public string Content { get; set; }
  }
}

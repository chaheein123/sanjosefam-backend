using System;
namespace sanjosefam_backend.Dtos.UserDto
{
  public class UserReadDto
  {
    public int Id { get; set; }

    public string UserName { get; set; }

    //public string UserEmail { get; set; }

    public string UserJob { get; set; }

    public string UserRealName { get; set; }

    public string UserIntro { get; set; }

    public string UserImg { get; set; }

  }
}

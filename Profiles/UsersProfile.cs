using System;
using AutoMapper;
using sanjosefam_backend.Dtos.UserDto;
using sanjosefam_backend.Models;

namespace sanjosefam_backend.Profiles
{
  public class UsersProfile : Profile
  {
    public UsersProfile()
    {
      CreateMap<User, UserReadDto>();
      CreateMap<UserRegisterDto, User>();
    }
  }
}

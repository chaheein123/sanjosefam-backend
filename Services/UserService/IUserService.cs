using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using sanjosefam_backend.Dtos.UserDto;
using sanjosefam_backend.Models;

namespace sanjosefam_backend.Services.UserService
{
  public interface IUserService
  {
    Task<ServiceResponse<List<UserReadDto>>> GetAllUsers();
    //Task<ServiceResponse<User>> CreateUser(User user);
  }
}

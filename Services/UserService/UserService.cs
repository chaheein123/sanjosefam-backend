using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using sanjosefam_backend.Data;
using sanjosefam_backend.Dtos.UserDto;
using sanjosefam_backend.Models;

namespace sanjosefam_backend.Services.UserService
{
  public class UserService : IUserService
  {
    private readonly MainContext _context;
    private readonly IMapper _mapper;

    public UserService(MainContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<ServiceResponse<List<UserReadDto>>> GetAllUsers()
    {
      var users = await _context.Users.Select(user => _mapper.Map<UserReadDto>(user)).ToListAsync();

      var response = new ServiceResponse<List<UserReadDto>>();
      response.Data = users;
      return response;
    }

    //public async Task<ServiceResponse<User>> CreateUser(User user)
    //{
    //  await _context.AddAsync(user);
    //  bool changeSaved = await _context.SaveChangesAsync() >= 0;

    //  if (!changeSaved)
    //  {
    //    return new ServiceResponse<User>() { Message = "로드하는 중에 오류가 발생했습니다. 다시 시도하세요", Success = false };
    //  }

    //  ServiceResponse<User> serviceResponse = new ServiceResponse<User> { Data = user };
    //  return serviceResponse;
    //}
  }
}

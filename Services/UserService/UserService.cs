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

    //public async Task<ServiceResponse<List<UserReadDto>>> GetAllUsers()
    //{
    //  var users = await _context.Users.Select(user => _mapper.Map<UserReadDto>(user)).ToListAsync();

    //  var response = new ServiceResponse<List<UserReadDto>>();
    //  response.Data = users;
    //  return response;
    //}

    public async Task<UserReadDto> GetUserInfo(string userName)
    {
      var user = _mapper.Map<UserReadDto>(await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName));
      return user;
    }
  }
}

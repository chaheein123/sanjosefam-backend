using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sanjosefam_backend.Data.AuthRepository;
using sanjosefam_backend.Models;
using sanjosefam_backend.Services.UserService;

namespace sanjosefam_backend.Controllers
{
  //[Authorize]
  [Route("users")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
      _userService = userService;
    }

    [HttpGet("getuserinfo/{userName}", Name = "GetUserInfoByUserName")]
    public async Task<IActionResult> GetUserInfo(string userName)
    {
      var userInfo = await _userService.GetUserInfo(userName);
      if (userInfo == null) return BadRequest();
      return Ok(userInfo);
    }

  }
}

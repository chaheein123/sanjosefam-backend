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
  [Authorize]
  [Route("users")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
      _userService = userService;
    }

    //[AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
      return Ok(await _userService.GetAllUsers());
      
    }

  }
}

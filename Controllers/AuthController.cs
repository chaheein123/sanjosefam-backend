using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sanjosefam_backend.Data.AuthRepository;
using sanjosefam_backend.Dtos.UserDto;
using sanjosefam_backend.Models;

namespace sanjosefam_backend.Controllers
{
  [Route("auth")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly IAuthRepository _authRepo;

    public AuthController(IAuthRepository authRepo)
    {
      _authRepo = authRepo;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegisterDto request)
    {
      ServiceResponse<string> response = await _authRepo.Register(new User { UserName = request.UserName, UserEmail = request.UserEmail }, request.UserPw);

      if (!response.Success) return Ok(response);

      var cookieOptions = new CookieOptions
      {
        Secure = false,
        HttpOnly = false,
        SameSite = SameSiteMode.Strict,
        Expires = DateTime.UtcNow.AddDays(7)
      };

      Response.Cookies.Append("token", response.Data, cookieOptions);
      response.Data = null;
      return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginDto request)
    {
      ServiceResponse<string> response = await _authRepo.Login(request.UserEmail, request.UserPw);

      if (!response.Success) return Ok(response);
      var cookieOptions = new CookieOptions
      {
        Secure = false,
        HttpOnly = false,
        SameSite = SameSiteMode.Strict,
        Expires = DateTime.UtcNow.AddDays(7)
      };
      Response.Cookies.Append("token", response.Data, cookieOptions);
      response.Data = null;
      return Ok(response);
    }
  }
}

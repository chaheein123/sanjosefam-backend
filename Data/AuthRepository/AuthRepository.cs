using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using sanjosefam_backend.Models;

namespace sanjosefam_backend.Data.AuthRepository
{
  public class AuthRepository : IAuthRepository
  {
    private readonly MainContext _context;

    private readonly IConfiguration _configuration;

    public AuthRepository(MainContext context, IConfiguration configuration)
    {
      _context = context;
      _configuration = configuration;

    }

    //public async Task<bool> UserExists(string userEmail, string userName)
    //{
    //  if (await _context.Users.AnyAsync(x => x.UserName.ToLower() == userName)) return true;
    //  return false;
    //}

    public async Task<ServiceResponse<string>> Register(User user, string userPw)
    {
      ServiceResponse<string> response = new ServiceResponse<string>();
      if (await _context.Users.AnyAsync(x => x.UserEmail.ToLower() == user.UserEmail.ToLower()))
      {
        response.Success = false;
        response.Message = "이미 등록이 되있는 이메일주소 입니다. 다시 입력해 주세요";
        return response;
      }
      else if (await _context.Users.AnyAsync(x => x.UserName.ToLower() == user.UserName.ToLower())) {
        response.Success = false;
        response.Message = "이미 등록이 되있는 닉네임 입니다. 다시 입력해 주세요";
        return response;
      }

      CreatePasswordHash(userPw, out byte[] passwordHash, out byte[] passwordSalt);
      user.PasswordHash = passwordHash;
      user.PasswordSalt = passwordSalt;
      await _context.Users.AddAsync(user);
      await _context.SaveChangesAsync();
      response.Data = CreateToken(user);
      return response;
    }

    public async Task<ServiceResponse<string>> Login(string userEmail, string userPw)
    {
      ServiceResponse<string> response = new ServiceResponse<string>();
      User user = await _context.Users.FirstOrDefaultAsync(x => x.UserEmail.ToLower() == userEmail);

      if (user == null)
      {
        response.Success = false;
        response.Message = "등록돼 있지않는 이메일 주소입니다.";

      }
      else if (!VerifyPasswordHash(userPw, user.PasswordHash, user.PasswordSalt))
      {
        response.Success = false;
        response.Message = "비밀번호가 맞지 않습니다";
      }
      else
      {
        response.Data = CreateToken(user);
      }
      return response;
    }

    private void CreatePasswordHash(string userPw, out byte[] passwordHash, out byte[] passwordSalt)
    {
      using (var hmac = new System.Security.Cryptography.HMACSHA512())
      {
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(userPw));

      }
    }

    private bool VerifyPasswordHash(string userPw, byte[] passwordHash, byte[] passwordSalt)
    {
      using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
      {
        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(userPw));
        for (int i=0; i<computedHash.Length; i++)
        {
          if(computedHash[i] != passwordHash[i])
          {
            return false;
          }
        }
        return true;
      }
    }

    private string CreateToken(User user)
    {
      List<Claim> claims = new List<Claim>
      {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.UserName)
      };

      SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

      SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

      SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.Now.AddDays(7),
        SigningCredentials = creds
      };

      JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
      SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);


    }
  }
}

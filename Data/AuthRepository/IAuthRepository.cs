using System;
using System.Threading.Tasks;
using sanjosefam_backend.Models;

namespace sanjosefam_backend.Data.AuthRepository
{
  public interface IAuthRepository
  {
    Task<ServiceResponse<string>> Register(User user, string userPw);

    //Task<ServiceResponse<User>> Login(string userEmail, string userPw);

    //Task<bool> UserExists(string userEmail, string userName);
    Task<ServiceResponse<string>> Login(string userEmail, string userPw);
   }
}

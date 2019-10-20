using System.Threading.Tasks;
using Server.Models;
using Shared;

namespace Server.Data.Interfaces
{
  public interface IAuthRepository
  {
    Task<User> Register(User user, string password);
    Task<User> Login(UserLoginDto user);
    Task<bool> UserExists(string username);
  }
}

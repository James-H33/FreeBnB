using System.Threading.Tasks;
using Server.Models;
using Shared;

namespace Server.Services.Interfaces
{
  public interface IAuthService
  {
    Task<TokenDto> Login(UserLoginDto userLoginDto);
    Task<bool> Register(UserForRegister user);
  }
}

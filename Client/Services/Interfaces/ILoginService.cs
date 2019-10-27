using System.Threading.Tasks;
using FreeBnB.Shared;

namespace Services.Interfaces
{
  public interface ILoginService
  {
    Task<bool> Login(UserLoginDto loginDto);
  }
}

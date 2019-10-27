using System.Threading.Tasks;
using Server.Models;
using FreeBnB.Shared;

namespace Server.Data.Interfaces
{
  public interface IUsersRepository
  {
    Task<User> GetUser(int id);
  }
}

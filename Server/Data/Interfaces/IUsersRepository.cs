using System.Threading.Tasks;
using Server.Models;
using Shared;

namespace Server.Data.Interfaces
{
  public interface IUsersRepository
  {
    Task<User> GetUser(int id);
  }
}

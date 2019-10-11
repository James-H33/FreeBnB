using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Data.Interfaces
{
  public interface IHomesRepository : IGenericRepository
  {
    Task<IEnumerable<Home>> GetHomes();

    Task<Home> GetHome(int id);
  }
}

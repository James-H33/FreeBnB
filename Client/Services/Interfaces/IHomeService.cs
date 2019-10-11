using System.Collections.Generic;
using System.Threading.Tasks;
using FreeBnB.Shared;

namespace Services.Interfaces
{
  public interface IHomeService
  {
    Task<List<Home>> GetHomes();
    Task<Home> GetHome();
  }
}

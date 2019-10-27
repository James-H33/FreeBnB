using System.Threading.Tasks;
using Server.Data.Interfaces;

namespace Server.Data
{
  public class UsersRepository : IGenericRepository
  {
    public void Add<T>(T entity) where T : class
    {
      throw new System.NotImplementedException();
    }

    public void Delete<T>(T entity) where T : class
    {
      throw new System.NotImplementedException();
    }

    public Task<bool> SaveAll()
    {
      throw new System.NotImplementedException();
    }
  }
}

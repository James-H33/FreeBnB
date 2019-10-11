using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Data.Interfaces
{
  public interface IGenericRepository
  {
    void Add<T>(T entity) where T: class;

    void Delete<T>(T entity) where T: class;

    Task<bool> SaveAll();
  }
}

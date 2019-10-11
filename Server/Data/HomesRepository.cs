using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Data.Interfaces;
using Server.Models;

namespace Server.Data
{
  public class HomesRepository : IHomesRepository
  {
    public DataContext _context { get; }

    public HomesRepository(DataContext context)
    {
      _context = context;
    }

    public void Add<T>(T entity) where T : class
    {
      _context.Add(entity);
    }

    public void Delete<T>(T entity) where T : class
    {
      _context.Remove(entity);
    }

    public async Task<Home> GetHome(int id)
    {
      var home = await _context.Homes
        .Include(p => p.Photos)
        .FirstOrDefaultAsync(h => h.Id == id);

        return home;
    }

    public async Task<IEnumerable<Home>> GetHomes()
    {
      var homes = await _context.Homes.Include(h => h.Photos).ToListAsync();

      return homes;
    }

    public async Task<bool> SaveAll()
    {
      return await _context.SaveChangesAsync() > 0;
    }
  }
}

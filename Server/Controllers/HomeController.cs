using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;

namespace Server.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class HomeController : ControllerBase
  {
    private readonly DataContext _db;

    public HomeController(DataContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<Home>>> Get()
    {
      var res = await _db.Homes.ToListAsync();

      return Ok(res);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Home>> GetHome(int id)
    {
      var res = await _db.Homes.FirstOrDefaultAsync(x => x.Id.Equals(id));

      return res != null ? Ok(res) : Ok(null);
    }
  }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Data.Interfaces;
using Server.Models;

namespace FreeBnB.Server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class HomesController : ControllerBase
  {
    private readonly IHomesRepository _repo;

    public HomesController(IHomesRepository repo)
    {
      _repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult<List<Home>>> Get()
    {
      var res = await _repo.GetHomes();

      return Ok(res);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Home>> GetHome(int id)
    {
      var res = await _repo.GetHome(id);

      return res != null ? Ok(res) : Ok(null);
    }
  }
}

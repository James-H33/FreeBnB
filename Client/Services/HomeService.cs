using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FreeBnB.Shared;
using Newtonsoft.Json;
using Services.Interfaces;

namespace Services
{
  public class HomeService : IHomeService
  {
    private readonly HttpClient _http;

    public HomeService(HttpClient http)
    {
      _http = http;
    }

    public Task<Home> GetHome()
    {
      throw new System.NotImplementedException();
    }

    public async Task<List<Home>> GetHomes()
    {
      var response = await _http.GetStringAsync("api/homes");
      var results = JsonConvert.DeserializeObject<List<Home>>(response);

      return results;
    }
  }
}
